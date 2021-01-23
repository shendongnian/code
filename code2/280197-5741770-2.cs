    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    namespace StackOverflow
    {
        /*
         * breadth-first lazy search across a subset of the call tree rooting in startingPoint
         * 
         * methodSelect selects the methods to recurse into
         * resultGen generates the result objects to be returned by the enumerator
         * 
         */
        class CallTreeSearch<T> : BaseCodeVisitor, IEnumerable<T> where T : class
        {
            private readonly Func<MethodReference, bool> _methodSelect;
            private readonly Func<Instruction, Stack<MethodReference>, T> _transform;
            private readonly IEnumerable<MethodDefinition> _startingPoints;
            private readonly IDictionary<MethodDefinition, Stack<MethodReference>> _chain = new Dictionary<MethodDefinition, Stack<MethodReference>>();
            private readonly ICollection<MethodDefinition> _seen = new HashSet<MethodDefinition>(new CompareMembers<MethodDefinition>());
            private readonly ICollection<T> _results = new HashSet<T>();
            private Stack<MethodReference> _currentStack;
            private const int InfiniteRecursion = -1;
            private readonly int _maxrecursiondepth;
            private bool _busy;
            public CallTreeSearch(IEnumerable<MethodDefinition> startingPoints,
                                  Func<MethodReference, bool> methodSelect,
                                  Func<Instruction, Stack<MethodReference>, T> resultGen)
                : this(startingPoints, methodSelect, resultGen, InfiniteRecursion)
            {
            }
            public CallTreeSearch(IEnumerable<MethodDefinition> startingPoints,
                                  Func<MethodReference, bool> methodSelect,
                                  Func<Instruction, Stack<MethodReference>, T> resultGen,
                                  int maxrecursiondepth)
            {
                _startingPoints = startingPoints.ToList();
                _methodSelect = methodSelect;
                _maxrecursiondepth = maxrecursiondepth;
                _transform = resultGen;
            }
            public override void VisitMethodBody(MethodBody body)
            {
                _seen.Add(body.Method); // avoid infinite recursion
                base.VisitMethodBody(body);
            }
            public override void VisitInstructionCollection(InstructionCollection instructions)
            {
                foreach (Instruction instr in instructions)
                    VisitInstruction(instr);
                base.VisitInstructionCollection(instructions);
            }
            public override void VisitInstruction(Instruction instr)
            {
                T result = _transform(instr, _currentStack);
                if (result != null)
                    _results.Add(result);
                var methodRef = instr.Operand as MethodReference; // TODO select calls only?
                if (methodRef != null && _methodSelect(methodRef))
                {
                    var resolve = methodRef.Resolve();
                    if (null != resolve && !(_chain.ContainsKey(resolve) || _seen.Contains(resolve)))
                        _chain.Add(resolve, new Stack<MethodReference>(_currentStack.Reverse()));
                }
                base.VisitInstruction(instr);
            }
            public IEnumerator<T> GetEnumerator()
            {
                lock (this) // not multithread safe
                {
                    if (_busy)
                        throw new InvalidOperationException("CallTreeSearch enumerator is not reentrant");
                    _busy = true;
                    try
                    {
                        int recursionLevel = 0;
                        ResetToStartingPoints();
                        while (_chain.Count > 0 &&
                               ((InfiniteRecursion == _maxrecursiondepth) || recursionLevel++ <= _maxrecursiondepth))
                        {
                            // swapout the collection because Visitor will modify
                            var clone = new Dictionary<MethodDefinition, Stack<MethodReference>>(_chain);
                            _chain.Clear();
                            foreach (var call in clone.Where(call => HasBody(call.Key)))
                            {
    //                          Console.Error.Write("\rCallTreeSearch: level #{0}, scanning {1,-20}\r", recursionLevel, call.Key.Name + new string(' ',21));
                                _currentStack = call.Value;
                                _currentStack.Push(call.Key);
                                try
                                {
                                    _results.Clear();
                                    call.Key.Body.Accept(this); // grows _chain and _results
                                }
                                finally
                                {
                                    _currentStack.Pop();
                                }
                                _currentStack = null;
                                foreach (var result in _results)
                                    yield return result;
                            }
                        }
                    }
                    finally
                    {
                        _busy = false;
                    }
                }
            }
            private void ResetToStartingPoints()
            {
                _chain.Clear();
                _seen.Clear();
                foreach (var startingPoint in _startingPoints)
                {
                    _chain.Add(startingPoint, new Stack<MethodReference>());
                    _seen.Add(startingPoint);
                }
            }
            private static bool HasBody(MethodDefinition methodDefinition)
            {
                return !(methodDefinition.IsAbstract || methodDefinition.Body == null);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        internal class CompareMembers<T> : IComparer<T>, IEqualityComparer<T>
            where T: class, IMemberReference
        {
            public int Compare(T x, T y)
            { return StringComparer.InvariantCultureIgnoreCase.Compare(KeyFor(x), KeyFor(y)); }
            public bool Equals(T x, T y)
            { return KeyFor(x).Equals(KeyFor(y)); }
            private static string KeyFor(T mr)
            { return null == mr ? "" : String.Format("{0}::{1}", mr.DeclaringType.FullName, mr.Name); }
            public int GetHashCode(T obj)
            { return KeyFor(obj).GetHashCode(); }
        }
    }

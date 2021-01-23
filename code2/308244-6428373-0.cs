    using System;
    using System.Linq;
    using Microsoft.FxCop.Sdk;
    using System.Collections.Generic;
    class CheckUpdatableComponents : BaseIntrospectionRule
    {
        // private string[] MethodsToCheckNames = new string[] { "BeginDraw", "BeginRun", "Draw", "EndRun", "EndDraw", "Update" };
        /// <summary>Gets the base class hooked up.</summary>
        public CheckUpdatableComponents()
            : base("CheckUpdatableComponents", "FxCopRules.Rules", typeof(CheckUpdatableComponents).Assembly)
        {
        }
        public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            if (method != null)
            {
                if (ShouldCheckMethod(method))
                {
                    foreach (var Instruction in method.Instructions)
                    {
                        if (Instruction.NodeType == NodeType.Box ||
                            Instruction.NodeType == NodeType.Unbox ||
                            Instruction.NodeType == NodeType.UnboxAny ||
                            Instruction.OpCode == OpCode.Box ||
                            Instruction.OpCode == OpCode.Unbox ||
                            Instruction.OpCode == OpCode.Unbox_Any)
                        {
                            Problems.Add(new Problem(GetResolution(), Instruction, Instruction.SourceContext.StartLine.ToString()));
                        }
                    }
                }
            }
            return Problems;
        }
        public bool ShouldCheckMethod(Method method)
        {
            Queue<Method> MethodsToCheck = new Queue<Method>();
            List<Method> MethodsChecked = new List<Method>();
            MethodsToCheck.Enqueue(method);
            while (MethodsToCheck.Count != 0)
            {
                Method MethodToCheck = MethodsToCheck.Dequeue();
                if (!MethodsChecked.Contains(MethodToCheck) && MethodToCheck != null)
                {
                    /*if (IsSubClassOf(MethodToCheck.DeclaringType, "Microsoft.Xna.Framework.Game") &&
                        MethodsToCheckNames.Contains(MethodToCheck.Name.Name))
                    {
                        return true;
                    }*/
                    foreach (var attribute in MethodToCheck.Attributes.Union(MethodToCheck.DeclaringType.Attributes))
                    {
                        if (attribute.Type != null &&
                            attribute.Type.FullName == "GridEngine.Components.Debugging.Attributes.FxCop.PerformanceCriticalAttribute")
                        {
                            return true;
                        }
                    }
                    // Add methods up the class tree
                    MethodsToCheck.Enqueue(MethodToCheck.OverriddenMethod);
                    MethodsToCheck.Enqueue(MethodToCheck.HiddenMethod);
                
                    // Add calling methods
                    foreach (var CallingMethod in CallGraph.CallersFor(MethodToCheck))
                    {
                        MethodsToCheck.Enqueue(CallingMethod);
                    }
                }
                MethodsChecked.Add(MethodToCheck);
            }
            return false;
        }
        private bool IsSubClassOf(TypeNode type, string typeName)
        {
            if (type.FullName == typeName)
                return true;
            if (type.BaseType == null)
                return false;
            else
                return IsSubClassOf(type.BaseType, typeName);
        }
    }

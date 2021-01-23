    public class CallGraphBuilder : BinaryReadOnlyVisitor
    {
        public Dictionary<TypeNode, List<TypeNode>> ChildTypes;
        public Dictionary<Method, List<Method>> CallersOfMethod;
        private Method _CurrentMethod;
        public CallGraphBuilder()
            : base()
        {
            CallersOfMethod = new Dictionary<Method, List<Method>>();
            ChildTypes = new Dictionary<TypeNode, List<TypeNode>>();
        }
        public override void VisitMethod(Method method)
        {
            _CurrentMethod = method;
            base.VisitMethod(method);
        }
        public void CreateTypesTree(AssemblyNode Assy)
        {
            foreach (var Type in Assy.Types)
            {
                if (Type.FullName != "System.Object")
                {
                    TypeNode BaseType = Type.BaseType;
                    if (BaseType != null && BaseType.FullName != "System.Object")
                    {
                        if (!ChildTypes.ContainsKey(BaseType))
                            ChildTypes.Add(BaseType, new List<TypeNode>());
                        if (!ChildTypes[BaseType].Contains(Type))
                            ChildTypes[BaseType].Add(Type);
                    }
                }
            }
        }
        public override void VisitMethodCall(MethodCall call)
        {
            Method CalledMethod = (call.Callee as MemberBinding).BoundMember as Method;
            AddCallerOfMethod(CalledMethod, _CurrentMethod);
            Queue<Method> MethodsToCheck = new Queue<Method>();
            MethodsToCheck.Enqueue(CalledMethod);
            while (MethodsToCheck.Count != 0)
            {
                Method CurrentMethod = MethodsToCheck.Dequeue();
                if (ChildTypes.ContainsKey(CurrentMethod.DeclaringType))
                {
                    foreach (var DerivedType in ChildTypes[CurrentMethod.DeclaringType])
                    {
                        var DerivedCalledMethod = DerivedType.Members.OfType<Method>().Where(M => MethodHidesMethod(M, CurrentMethod)).SingleOrDefault();
                        if (DerivedCalledMethod != null)
                        {
                            AddCallerOfMethod(DerivedCalledMethod, CurrentMethod);
                            MethodsToCheck.Enqueue(DerivedCalledMethod);
                        }
                    }
                }
            }
            base.VisitMethodCall(call);
        }
        private void AddCallerOfMethod(Method CalledMethod, Method CallingMethod)
        {
            if (!CallersOfMethod.ContainsKey(CalledMethod))
                CallersOfMethod.Add(CalledMethod, new List<Method>());
            if (!CallersOfMethod[CalledMethod].Contains(CallingMethod))
                CallersOfMethod[CalledMethod].Add(CallingMethod);
        }
        private bool MethodHidesMethod(Method ChildMethod, Method BaseMethod)
        {
            while (ChildMethod != null)
            {
                if (ChildMethod == BaseMethod)
                    return true;
                ChildMethod = ChildMethod.OverriddenMethod ?? ChildMethod.HiddenMethod;
            }
            return false;
        }
    }

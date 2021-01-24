        public static void DoSmth1<T1, T2>(IEnumerable<KeyValuePair<T1, T2>> collection)
            where T2 : struct
        {
        }
        public static void DoSmth2<T>(T val)
        {
        }
        public static void DoSmth3<T>(IEnumerable<T> val)
        {
        }
        static (bool, GenericParamInfo[]) TestResolveMethodType(Type argToResolve, string methodName)
        {
            MethodInfo methodInfo = typeof(Program).GetMethod(methodName);
            //assuming that we always try to resolve the first method parameter for simplicity
            Type genericArgType = methodInfo.GetParameters()[0].ParameterType;
            GenericParamInfo[] typesToConcretize =
                methodInfo.GetGenericArguments().Select(t => new GenericParamInfo(t)).ToArray();
            bool result = argToResolve.ResolveType(genericArgType, typesToConcretize);
            return (result, typesToConcretize);
        }
        static void Main(string[] args)
        {
            (bool result1, GenericParamInfo[] concretizedTypes1) = 
                TestResolveMethodType(typeof(Dictionary<int, double>), nameof(DoSmth1));
            (bool result2, GenericParamInfo[] concretizedTypes2) =
                TestResolveMethodType(typeof(int), nameof(DoSmth2));
            (bool result3, GenericParamInfo[] concretizedTypes3) =
                TestResolveMethodType(typeof(List<int>), nameof(DoSmth3));
        }

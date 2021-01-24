    public static class Program
    {
        private const int maxTupleMembers = 7;
        private const int maxTupleArity = maxTupleMembers + 1;
        private static readonly Type[] tupleTypes = new[]
        {
            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>),
            typeof(ValueTuple<,,,,,,,>),
        };
        public static void Main()
        {
            var a = CreateTuple(new[] { 1 });
            var b = CreateTuple(new[] { 1, 2, 3, 4, 5, 6, 7 });
            var c = CreateTuple(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            var d = CreateTuple(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            var e = CreateTuple(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15 });
        }
        private static object CreateTuple<T>(IReadOnlyList<T> values)
        {
            int numTuples = (int)Math.Ceiling((double)values.Count / maxTupleMembers);
            object currentTuple = null;
            Type currentTupleType = null;
            // We need to work backwards, from the last tuple
            for (int tupleIndex = numTuples - 1; tupleIndex >= 0; tupleIndex--)
            {
                bool hasRest = currentTuple != null;
                int numTupleMembers = hasRest ? maxTupleMembers : values.Count - (maxTupleMembers * tupleIndex);
                int tupleArity = numTupleMembers + (hasRest ? 1 : 0);
                var typeArguments = new Type[tupleArity];
                object[] ctorParameters = new object[tupleArity];
                for (int i = 0; i < numTupleMembers; i++)
                {
                    typeArguments[i] = typeof(T);
                    ctorParameters[i] = values[tupleIndex * maxTupleMembers + i];
                }
                if (hasRest)
                {
                    typeArguments[typeArguments.Length - 1] = currentTupleType;
                    ctorParameters[ctorParameters.Length - 1] = currentTuple;
                }
                currentTupleType = tupleTypes[tupleArity - 1].MakeGenericType(typeArguments);
                currentTuple = currentTupleType.GetConstructors()[0].Invoke(ctorParameters);
            }
            return currentTuple;
        }
    }

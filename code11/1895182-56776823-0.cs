    public class ArrayWrapper<T> where T : struct
    {
        public ArrayWrapper(int structsCount)
        {
            var fields = typeof(T)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            // do some check
            if (fields.Any(f => f.FieldType != typeof(int)))
                throw new Exception("Only int fields allowed");
            if (fields.Any(f => f.IsPrivate))
                throw new Exception("Only public fields allowed");
            InnerArray = new int[structsCount * fields.Length];
            copyFromArrayToStruct = CopyFromArrayToStructMethodBuilder(fields);
            copyFromStructToArray = CopyFromStructToArrayMethodBuilder(fields);
        }
        public int[] InnerArray { get; }
        private readonly Func<int, T> copyFromArrayToStruct;
        private readonly Action<int, T> copyFromStructToArray;
        public T this[int index]
        {
            get => copyFromArrayToStruct(index);
            set => copyFromStructToArray(index, value);
        }
        private Func<int, T> CopyFromArrayToStructMethodBuilder(FieldInfo[] fields)
        {
            var index = Expression.Parameter(typeof(int), "i");
            var actualOffset = Expression.Multiply(index, Expression.Constant(fields.Length));
            var result = Expression.Variable(typeof(T), "result");
            var lines = new List<Expression> {Expression.Assign(result, Expression.New(typeof(T)))};
            for (var i = 0; i < fields.Length; ++i)
            {
                var fieldInfo = fields[i];
                var left = Expression.Field(result, fieldInfo);
                var right = Expression.ArrayIndex(
                    Expression.Constant(InnerArray),
                    Expression.Add(actualOffset, Expression.Constant(i)));
                var assignment = Expression.Assign(left, right);
                lines.Add(assignment);
            }
            lines.Add(result);
            var lambda = Expression.Lambda<Func<int, T>>(Expression.Block(new []{result}, lines), index);
            return lambda.Compile();
        }
        private Action<int, T> CopyFromStructToArrayMethodBuilder(FieldInfo[] fields)
        {
            var index = Expression.Parameter(typeof(int), "i");
            var value = Expression.Parameter(typeof(T), "value");
            var actualOffset = Expression.Multiply(index, Expression.Constant(fields.Length));
            var lines = new List<Expression>();
            for (var i = 0; i < fields.Length; ++i)
            {
                var fieldInfo = fields[i];
                var left = Expression.ArrayAccess(Expression.Constant(InnerArray),
                    Expression.Add(actualOffset, Expression.Constant(i)));
                var right = Expression.Field(value, fieldInfo);
                var assignment = Expression.Assign(left, right);
                lines.Add(assignment);
            }
            var lambda = Expression.Lambda<Action<int, T>>(Expression.Block(lines), index, value);
            return lambda.Compile();
        }
    }

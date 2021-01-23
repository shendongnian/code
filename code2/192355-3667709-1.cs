    public static class Program {
        public static void Main() {
            var param = Expression.Parameter(typeof(DummyClass), "WageConstIn");
            var constValue = Expression.Constant("2800");
            var predicate = Expression.Lambda(
                parameters: param,
                body: Expression.Call(
                instance: Expression.Call(
                        instance: Expression.Property(param, "Serialno"),
                        methodName: "ToString",
                        typeArguments: null,
                        arguments: null
                    ),
                    methodName: "StartsWith",
                    typeArguments: null,
                    arguments: new[] { constValue }
                )
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<object, string> expr = CompileDataBinder(typeof(Model), "PocoProperty.Name");
            var model = new Model { PocoProperty = new ModelPoco { Name = "Foo" } };
            string propertyName = expr(model);
        }
        static Func<object, string> CompileDataBinder(Type type, string expr)
        {
            var param = Expression.Parameter(typeof(object));
            Expression body = Expression.Convert(param, type);
            var members = expr.Split('.');
            for (int i = 0; i < members.Length;i++ )
            {
                body = Expression.PropertyOrField(body, members[i]);
            }
            var method = typeof(Convert).GetMethod("ToString", BindingFlags.Static | BindingFlags.Public,
                null, new Type[] { body.Type }, null);
            if (method == null)
            {
                method = typeof(Convert).GetMethod("ToString", BindingFlags.Static | BindingFlags.Public,
                    null, new Type[] { typeof(object)}, null);
                body = Expression.Call(method, Expression.Convert(body, typeof(object)));
            }
            else
            {
                body = Expression.Call(method, body);
            }
            
            return Expression.Lambda<Func<object, string>>(body, param).Compile();
        }
    }
    class Model
    {
        public ModelPoco PocoProperty { get; set; }
    }
    class ModelPoco
    {
        public string Name { get; set; }
    }

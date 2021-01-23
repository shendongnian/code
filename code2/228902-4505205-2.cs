    static class Dumper
    {
        private readonly static Dictionary<Type, Action<object, TextWriter>> _dumpActions
            = new Dictionary<Type, Action<object, TextWriter>>();
        
        private static Action<object, TextWriter> CreateDumper(Type type)
        {
            MethodInfo writeLine1Obj = typeof(TextWriter).GetMethod("WriteLine", new[] { typeof(object) });
            MethodInfo writeLine1String2Obj = typeof(TextWriter).GetMethod("WriteLine", new[] { typeof(string), typeof(object), typeof(object) });
        
            ParameterExpression objParam = Expression.Parameter(typeof(object), "o");
            ParameterExpression outputParam = Expression.Parameter(typeof(TextWriter), "output");
            ParameterExpression objVariable = Expression.Variable(type, "o2");
            LabelTarget returnTarget = Expression.Label();
            List<Expression> bodyExpressions = new List<Expression>();
            
            bodyExpressions.Add(
                // o2 = (<type>)o
                Expression.Assign(objVariable, Expression.Convert(objParam, type)));
            
            bodyExpressions.Add(
                // output.WriteLine(o)
                Expression.Call(outputParam, writeLine1Obj, objParam));
                
            var properties =
                from prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                where prop.CanRead
                && !prop.GetIndexParameters().Any() // exclude indexed properties to keep things simple
                select prop;
    
            foreach (var prop in properties)
            {
                bool isNullable =
                    !prop.PropertyType.IsValueType ||
                    prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
                // (object)o2.<property> (cast to object to be passed to WriteLine)
                Expression propValue =
                     Expression.Convert(
                         Expression.Property(objVariable, prop),
                         typeof(object));
    
                if (isNullable)
                {
                    // (<propertyValue> ?? "null")
                    propValue =
                        Expression.Coalesce(
                            propValue,
                            Expression.Constant("null", typeof(object)));
                }
            
                bodyExpressions.Add(
                    // output.WriteLine("\t{0}: {1}", "<propertyName>", <propertyValue>)
                    Expression.Call(
                        outputParam,
                        writeLine1String2Obj,
                        Expression.Constant("\t{0}: {1}", typeof(string)),
                        Expression.Constant(prop.Name, typeof(string)),
                        propValue));
            }
            
            bodyExpressions.Add(Expression.Label(returnTarget));
    
            Expression<Action<object, TextWriter>> dumperExpr =
                Expression.Lambda<Action<object, TextWriter>>(
                    Expression.Block(new[] { objVariable }, bodyExpressions),
                    objParam,
                    outputParam);
    
            return dumperExpr.Compile();
        }
        
        public static void Dump(object o, TextWriter output)
        {
            if (o == null)
            {
                output.WriteLine("null");
            }
            
            Type type = o.GetType();
            Action<object, TextWriter> dumpAction;
            if (!_dumpActions.TryGetValue(type, out dumpAction))
            {
                dumpAction = CreateDumper(type);
                _dumpActions[type] = dumpAction;
            }
            dumpAction(o, output);
        }
    }

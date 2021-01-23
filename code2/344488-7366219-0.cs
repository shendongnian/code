    public class MicroRuleEngine
        {
            public bool PassesRules<T>(List<Rule> rules, T toInspect)
            {
                return this.CompileRules<T>(rules).Invoke(toInspect);
            }
            public Func<T, bool> CompileRule<T>(Rule r)
            {
                var paramUser = Expression.Parameter(typeof(T));
                Expression expr = BuildExpr<T>(r, paramUser);
    
                return Expression.Lambda<Func<T, bool>>(expr, paramUser).Compile();
            }
    
            public Func<T, bool> CompileRules<T>(IList<Rule> rules)
            {
                var paramUser = Expression.Parameter(typeof(T));
                List<Expression> expressions = new List<Expression>();
                foreach (var r in rules)
                {
                    expressions.Add(BuildExpr<T>(r, paramUser));
                }
                var expr = AndExpressions(expressions);
    
                return Expression.Lambda<Func<T, bool>>(expr, paramUser).Compile();
            }
    
            Expression AndExpressions(IList<Expression> expressions)
            {
                if(expressions.Count == 1)
                    return expressions[0];
                Expression exp = Expression.And(expressions[0], expressions[1]);
                for(int i = 2; expressions.Count > i; i++)
                {
                    exp = Expression.And(exp, expressions[i]);
                }
                return exp;
            }
    
            Expression BuildExpr<T>(Rule r, ParameterExpression param)
            {
                Expression propExpression;
                Type propType;
                ExpressionType tBinary;
                if (r.MemberName.Contains('.'))
                {
                    String[] childProperties = r.MemberName.Split('.');
                    var property = typeof(T).GetProperty(childProperties[0]);
                    var paramExp = Expression.Parameter(typeof(T), "SomeObject");
    
                    propExpression = Expression.PropertyOrField(param, childProperties[0]);
                    for (int i = 1; i < childProperties.Length; i++)
                    {
                        property = property.PropertyType.GetProperty(childProperties[i]);
                        propExpression = Expression.PropertyOrField(propExpression, childProperties[i]);
                    }
                    propType = propExpression.Type;
                }
                else
                {
                    propExpression = Expression.PropertyOrField(param, r.MemberName);
                    propType = propExpression.Type;
                }
                
                // is the operator a known .NET operator?
                if (ExpressionType.TryParse(r.Operator, out tBinary))
                {
                    var right = Expression.Constant(Convert.ChangeType(r.TargetValue, propType));
                    // use a binary operation, e.g. 'Equal' -> 'u.Age == 15'
                    return Expression.MakeBinary(tBinary, propExpression, right);
                }
                else
                {
                    var method = propType.GetMethod(r.Operator);
                    var tParam = method.GetParameters()[0].ParameterType;
                    var right = Expression.Constant(Convert.ChangeType(r.TargetValue, tParam));
                    // use a method call, e.g. 'Contains' -> 'u.Tags.Contains(some_tag)'
                    return Expression.Call(propExpression, method, right);
                }
            }
    
        }
        public class Rule
        {
            public string MemberName { get; set; }
            public string Operator { get; set; }
            public string TargetValue { get; set; }
        }

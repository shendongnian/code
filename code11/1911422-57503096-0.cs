    public interface IItem {
        Dictionary<string, string> attributes { get; set; }
    }
    
    class QueryClass {
        public string FieldName { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
    
        public QueryClass(string pInput) {
            var returned = RegexHelpers.SplitKeyValue(pInput); //just returns a string like "Make = Honda" into three parts
            if (returned != null) {
                FieldName = returned.Item1;
                Operator = returned.Item2;
                Value = returned.Item3;
            }
        }
    
        static MethodInfo getItemMI = typeof(Dictionary<string, string>).GetMethod("get_Item");
        static Dictionary<string, Func<Expression, Expression, Expression>> opTypes = new Dictionary<string, Func<Expression, Expression, Expression>> {
            { "==", (Expression lhs, Expression rhs) => Expression.MakeBinary(ExpressionType.Equal, lhs, rhs) },
            { ">=", (Expression lhs, Expression rhs) => Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, Expression.Call(lhs, typeof(String).GetMethod("CompareTo", new[] { typeof(string) }), rhs), Expression.Constant(0)) },
            { "CONTAINS",  (Expression lhs, Expression rhs) => Expression.Call(lhs, typeof(String).GetMethod("Contains"), rhs) }
        };
        static MemberInfo attribMI = typeof(IItem).GetMember("attributes")[0];
    
        public Expression AsExpression(ParameterExpression p) {
            var dictField = Expression.MakeMemberAccess(p, attribMI);
            var lhs = Expression.Call(dictField, getItemMI, Expression.Constant(FieldName));
            var rhs = Expression.Constant(Value);
    
            if (opTypes.TryGetValue(Operator, out var exprMakerFn))
                return exprMakerFn(lhs, rhs);
            else
                throw new InvalidExpressionException($"Unrecognized operator {Operator}");
        }
    }
    
    public class LinqBuilder {
        static Type TItems = typeof(IItem);
    
        static Expression BuildOneLINQ(object term, ParameterExpression parm) {
            switch (term) {
                case QueryClass qc: // d => d[qc.FieldName] qc.Operator qc.Value
                    return qc.AsExpression(parm);
                case List<object> subQuery:
                    return BuildLINQ(subQuery, parm);
                default:
                    throw new Exception();
            }
        }
    
        static Expression BuildLINQ(List<object> query, ParameterExpression parm) {
            Expression body = null;
            for (int queryIndex = 0; queryIndex < query.Count; ++queryIndex) {
                var term = query[queryIndex];
                switch (term) {
                    case string op:
                        var rhs = BuildOneLINQ(query[++queryIndex], parm);
                        var eop = (op == "AND") ? ExpressionType.AndAlso : ExpressionType.OrElse;
                        body = Expression.MakeBinary(eop, body, rhs);
                        break;
                    default:
                        body = BuildOneLINQ(term, parm);
                        break;
                }
            }
    
            return body;
        }
    
        public static Func<IItem, bool> BuildLINQ(List<object> query) {
            var parm = Expression.Parameter(TItems, "i");
            return Expression.Lambda<Func<IItem, bool>>(BuildLINQ(query, parm), parm).Compile();
        }
    }

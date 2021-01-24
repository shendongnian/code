    public class SqlServerSemesterMemberTranslator : IMemberTranslator
    {
        public Expression Translate(MemberExpression memberExpression)
        {
            if (memberExpression.Member.DeclaringType != typeof(Semester)) {
                return null;
            }
            var memberName = memberExpression.Member.Name;
            if (memberName == nameof(Semester.FirstDay)) {
                return new SqlFunctionExpression(
                    "DATEFROMPARTS",
                    typeof(DateTime),
                    new Expression[] {
                            new SqlFunctionExpression( "YEAR", typeof(int),new[] { memberExpression.Expression }),
                            new SqlFunctionExpression( "MONTH", typeof(int),new[] { memberExpression.Expression }),
                            Expression.Constant(1, typeof(int))
                    });
            }
            if (memberName == nameof(Semester.LastDay)) {
                return new SqlFunctionExpression(
                    "EOMONTH",
                    typeof(DateTime),
                    new Expression[] {
                            memberExpression.Expression
                    });
            }
            if (memberName == nameof(Semester.HalfYear)) {
                return Expression.Convert(
                    new SqlFunctionExpression(
                        "MONTH",
                        typeof(int),
                        new Expression[] {
                                memberExpression.Expression
                        }),
                    typeof(HalfYear));
            }
            if (memberName == nameof(Semester.Year)) {
                return new SqlFunctionExpression(
                    "YEAR",
                    typeof(int),
                    new Expression[] {
                            memberExpression.Expression
                    });
            }
            return null;
        }
    }

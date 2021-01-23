    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    namespace OrTree
    {
    public static class QueryExt
    {
        /// <summary>
        /// Adapted from http://blogs.msdn.com/b/phaniraj/archive/2008/07/17/set-based-operations-in-ado-net-data-services.aspx
        /// </summary>
        /// 
        public static IQueryable<T> IsIn<T, TV>(this IQueryable<T> query, IEnumerable<TV> values, Expression<Func<T, TV>> selector = null)
        {
            if (values == null)
            {
                return query;
            }
            // The parameter expression containing the Entity Type
            var param = Expression.Parameter(typeof(T), "param");
            var propertyExpr = selector == null ? (Expression)param : Expression.Invoke(selector, param); 
            var expressions = new List<Expression>();
            foreach (var value in values)
            {
                // Build a comparision expression which equates the selector with a value in the list
                // ex : e.Id == 1
                var nexps = NullableExpressionCheck(propertyExpr, Expression.Constant(value));
                expressions.Add(Expression.Equal(nexps.Item1, nexps.Item2));
            }
            // Convert the Filter Expressions into a Lambda expression of type Func<Lists,bool>
            // which means that this lambda expression takes an instance of type EntityType and returns a Bool
            if (expressions.Any())
            {
                Expression filterPredicate = GenerateOrTree(expressions, 0, expressions.Count - 1);
                var filterLambdaExpression = Expression.Lambda<Func<T, bool>>(filterPredicate, param);
                return query.Where(filterLambdaExpression);
            }
            return query;
        }
        /// <summary>
        /// Take a list of expression and build a balanced or tree.  This is useful when there is a large number
        /// of expressions that will be or'ed together.  Linq, by default builds a recursive tree and you may hit the
        /// recursion limit of 100.  By building a balanced tree you will get the same results but with a much shallower 
        /// tree. 
        /// Added from http://stackoverflow.com/questions/2940045/building-flat-rather-than-tree-linq-expressions
        /// </summary>
        /// <param name="exprs">List of expressions to add</param>
        /// <param name="start">Start index in the list</param>
        /// <param name="end">End index in the list</param>
        /// <returns>Combined expression tree as a single expression</returns>
        public static Expression GenerateOrTree(IList<Expression> exprs, int start, int end)
        {
            // End of the recursive processing - return single element
            if (start == end)
            {
                return exprs[start];
            }
            // Split the list between two parts of (roughly the same size)
            var mid = start + ((end - start) / 2);
            // Process the two parts recursively and join them using OR
            var left = GenerateOrTree(exprs, start, mid);
            var right = GenerateOrTree(exprs, mid + 1, end);
            return Expression.Or(left, right);
        }
        public static Tuple<Expression, Expression> NullableExpressionCheck(Expression e1, Expression e2)
        {
            if (e1.Type.IsValueType && e2.Type == typeof(Object))
            {
                e2 = Expression.Convert(e2, typeof(Nullable<>).MakeGenericType(e1.Type));
            }
            if (e2.Type.IsValueType && e1.Type == typeof(Object))
            {
                e1 = Expression.Convert(e1, typeof(Nullable<>).MakeGenericType(e2.Type));
            }
            if (IsNullableType(e1.Type) && !IsNullableType(e2.Type))
                e2 = Expression.Convert(e2, e1.Type);
            else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type))
                e1 = Expression.Convert(e1, e2.Type);
            return new Tuple<Expression, Expression>(e1, e2);
        }
        public static bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
    public enum TestEnum
    {
        One,
        Two,
        Three,
        Four
    }
    public class TestClass
    {
        public int Id { get; set; }
        public TestEnum MyEnum { get; set; }
    }
    public class Test2
    {
        public DateTime StartDate { get; set; }
        public TestEnum MyEnum { get; set; }
    }
    public class Program
    {
        public Program()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var result = list.AsQueryable().IsIn(new List<int> { 1, 10, 13, 21 });
            var enumList = new List<TestEnum> { TestEnum.One, TestEnum.Two, TestEnum.Three, TestEnum.Four };
            var enumResult = enumList.AsQueryable().IsIn(new List<TestEnum> { TestEnum.Four });
            var classList = new List<TestClass>
                {
                    new TestClass { Id = 1, MyEnum = TestEnum.One }, 
                    new TestClass { Id = 2, MyEnum = TestEnum.Two }, 
                    new TestClass { Id = 3, MyEnum = TestEnum.Three },
                    new TestClass { Id = 4, MyEnum = TestEnum.Four }
                };
            var classResult = classList.AsQueryable().IsIn(new List<TestEnum> { TestEnum.Four }, r=>r.MyEnum);
            var dateList = new List<Test2> 
            { 
                new Test2 { StartDate = DateTime.Now.AddDays(1), MyEnum = TestEnum.One },
                new Test2 { StartDate = DateTime.Now.AddDays(2), MyEnum = TestEnum.Two },
                new Test2 { StartDate = DateTime.Now.AddDays(3), MyEnum = TestEnum.Three },
                new Test2 { StartDate = DateTime.Now.AddDays(4), MyEnum = TestEnum.Four },
                new Test2 { StartDate = DateTime.Now.AddDays(5), MyEnum = TestEnum.Four } 
            };
            var startDate = DateTime.Now.AddDays(2);
            var endDate = DateTime.Now.AddDays(4);
            // Update function dynamically if needed
            Func<DateTime, bool> dateRange = a => a >= startDate && a <= endDate;
            // Build this list dynamically
            var orValues = new List<TestEnum> { TestEnum.One, TestEnum.Four };
            //Call the where clause, convert to Queryable, and apply IsIn to create needed where clauses
            var dateResult = dateList.Where(t => dateRange(t.StartDate)).AsQueryable().IsIn(orValues, t=>t.MyEnum);
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}

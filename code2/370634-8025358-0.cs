    public class LinqAsParameter
    {
        public class Dummy
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public void Test()
        {
            var dummies = new List<Dummy>
            {
                new Dummy { Name = "Jon", Age = 30 },
                new Dummy { Name = "Will", Age = 27 },
            };
            // Calling the custom select method
            IEnumerable<int> ages = dummies.CustomSelect(o => o.Age);
        }
    }
    // extension class
    public static class IEnumerableExtenderLinqAsParameter
    {
        // extension method
        public static IEnumerable<TResult> CustomSelect<TSource, TResult>(
            this IEnumerable<TSource> e
          , Expression<Func<TSource, TResult>> exp)
        {
            // from the MemberExpression you can get the Member name
            var memberExpression = exp.Body as MemberExpression;
            var field = memberExpression.Member.Name; // name
            var compiledExp = exp.Compile(); // compiling the exp to execute
                                             // and retrieve the resulting value
            // run the list an get the value for each item
            foreach (TSource item in e)
            {
                yield return compiledExp(item);
            }
        }
    }

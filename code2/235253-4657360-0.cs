    class Foo
    {
        public string Bar { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var result = Get<Foo, string>(x => x.Bar);
            Console.WriteLine(result);
        }
    
        static string Get<T, TResult>(Expression<Func<T, TResult>> expression)
        {
            var me = expression.Body as MemberExpression;
            if (me != null)
            {
                return me.Member.Name;
            }
            return null;
        }
    }

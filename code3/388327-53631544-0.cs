    interface IQueryProcessor
    {
         void Process<TQuery, TResult>(TQuery query, out TResult result)
             where TQuery : IQuery<TResult>;
    }
    class Test
    {
        void Test(IQueryProcessor p)
        {
            var query = new SomeQuery();
            // Instead of
            // string result = p.Process<SomeQuery, string>(query);
            // You write
            string result;
            p.Process(query, out result);
        }
    }

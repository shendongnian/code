        static void Main(string[] args)
        {
            var t = new DataTable();
            t.Columns.Add("age", typeof(Int32));
            t.Columns.Add("gender", typeof(string));
            t.Columns.Add("name", typeof(string));
            t.Rows.Add(20, "M", "Steve");
            t.Rows.Add(5, "M", "John");
            t.Rows.Add(32, "F", "Mary");
            Expression<Func<int, bool>> ageexpr;
            ParameterExpression numparam = Expression.Parameter(typeof(int), "age");
            ConstantExpression criteriaValue1 = Expression.Constant(Convert.ToInt32(10), typeof(int));
            BinaryExpression comparison1 = Expression.GreaterThan(numparam, criteriaValue1);
            ageexpr = Expression.Lambda<Func<int, bool>>(
                    comparison1,
                   new ParameterExpression[] { numparam });
            Func<int, bool> resultage = ageexpr.Compile();
            // Invoking the delegate and writing the result to the console.
            bool firstrule = resultage(14);
            Console.WriteLine("1st Rule" + firstrule);
            DataView res1 = t.AsEnumerable().Where(r=> resultage(r.Field<Int32>("age"))).AsDataView();
        }

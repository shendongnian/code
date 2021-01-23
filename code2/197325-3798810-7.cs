        static void Main(string[] args)
        {
            const string DB_CONN = @"Data Source=.;Initial Catalog=Test;Integrated Security=SSPI;";
            var builder = new ContextBuilder<MyModel>();
            var connection = new SqlConnection(DB_CONN);
            using (var ctx = builder.Create(connection))
            {
                if (ctx.DatabaseExists())
                    ctx.DeleteDatabase();
                ctx.CreateDatabase();
            }
        }

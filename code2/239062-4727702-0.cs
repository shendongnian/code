        int i = Sql.UsingConnection("sample")
            .GetTextCommandFor("Select Top 1 ActorID From Actor Where FirstName = @fname")
            .AddParameters(new {fname = "Bob"})
            .OnException(e => Console.WriteLine(e.Message))
            .ExecuteScalar<int>();
        var q = Sql.UsingConnection("sample")
            .GetTextCommandFor("Select * From Actor Where FirstName=@fname and ActorID > @id")
            .AddParameters(new {id = 1000, fname = "Bob"});
            
        using(var reader = q.ExecuteReader())
        {
            while(reader.Read())
            {
                // do something
            }
        }

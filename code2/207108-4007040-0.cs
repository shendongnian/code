    var query = from c in Customers
                where c.ID < 15
                select c;
                
    using (var command = dc.GetCommand(query))
    {
        command.Connection.Open();
        using (var reader = command.ExecuteReader())
        {
            int i = 0;
            while (reader.Read())
            {
                Customer c = new Customer();
                c.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                c.Name = reader.GetString(reader.GetOrdinal("Name"));
                Console.WriteLine("{0}: {1}", c.ID, c.Name);
                i++;
                if (i > 3)
                    break;
            }
        }
    }

    string[] numbers = new string[] { "123", "234" };
    NpgsqlCommands cmd = new NpgsqlCommands("select * from products where number = ANY(:numbers)");
    NpgsqlParameter p = new NpgsqlParameter("numbers", NpgsqlDbType.Array | NpgsqlDbType.Text);
    p.value = numbers;
    command.Parameters.Add(p);

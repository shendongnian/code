    using (var reader = cmd.ExecuteReader())
    {
        if (reader.Read())
        {
            intQ = int.Parse(reader[0].ToString());
        }
        else
        {
            intQ = 0;
        }
    }
    txtblck.Text = intQ.ToString();

    var onlineList = new List<string>();
    if (result.HasRows)
    {
        while (result.Read())
        {
            Console.WriteLine(result["online"]);
            onlineList.Add(result["online"].ToString());
        }
    }

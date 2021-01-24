    public BindingList<UserModel> GetUsersAdvanced()
    {
        users = new BindingList<UserModel>();
        string[] lines = File.ReadAllLines("AdvancedDataSet.csv");
        var cols = lines.First().Split(',').ToList();
        // validate column name duplication here!
        foreach (var line in lines.Skip(1))
        {
            if (line != null)  data = line.Split(',');
            for (var i = 0; i < cols.Count(); i++)
            {
                var key = cols[i];
                var dict = new Dictionary<string, object>();
                if (data[i] == "0" || data[i] == "1")
                {
                    Boolean IsAlive = Extensions.ToBoolean(data[i]);
                    dict.Add(key, IsAlive);
                }
                else
                    dict.Add(key, data[i]);
                var currentUser = DictionaryToObject<UserModel>(dict);
                users.Add(currentUser);
            }
            return users;
        }
    }

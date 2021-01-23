    public void parseFromString(string input, out int id, out string name, out int count)
    {
        var split = input.Split(',');
        if(split.length == 3) // perhaps more validation here
        {
            id = int.Parse(split[0]);
            name = split[1];
            count = int.Parse(split[2]);     
        }
    }

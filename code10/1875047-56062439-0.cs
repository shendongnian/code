    public static async Task AddData() 
    {
        var data = new Data
        {
            id = "Hello",
            text = "World"
        };
        SetResponse response = await client.SetTaskAsync("0", data); //Change to SetTaskAsync here
        Data result = response.ResultAs<Data>();
    }

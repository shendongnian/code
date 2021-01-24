    private void button2_Click(object sender, EventArgs e)
    {
        object inputObject = new {ID = "56", AOID = "747"}; // create anonymous object
        string json =
        JsonConvert.SerializeObject(inputObject,
        new JsonSerializerSettings { ContractResolver = new CustomContractResolver() });
        Console.WriteLine(json);
    }

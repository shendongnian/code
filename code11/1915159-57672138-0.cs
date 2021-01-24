    public string getTest()
    {
       List<int> test = new List<int>();
       test.add(1);
       return JsonConvert.SerializeObject(test);
    }

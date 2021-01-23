    [OperationContract]
    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public List<Person> GetResults()
    {
        List<Person> results = new List<Person>();
        results.Add(new Person("Peyton", "Manning", 35));
        results.Add(new Person("Drew", "Brees", 31));
        results.Add(new Person("Tony", "Romo", 29));
        return results;
    }

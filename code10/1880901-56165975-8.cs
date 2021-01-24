    internal interface ISearch
    {
        string Query { get; }
        int Other { get; }
        bool ReturnValue { get; set; }
        string GetSomeOtherValue();
    }

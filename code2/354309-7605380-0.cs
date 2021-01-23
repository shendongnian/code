    interface ISomeInterface
    {
       string Id{get; set;}
       void Display();
    }
    interface IClassAInterface
    {
       Dictionary<string, string> DataValues{get;};
    }
    interface IClassBInterface
    {
       TypedDataSet MetaData{get; }
       IList<Record> RecordCollection{get; }
    }

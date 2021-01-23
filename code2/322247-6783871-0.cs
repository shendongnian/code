    public static int AFunctionIsThis<T>(T passedRecord) where T : DataType
    {
        var temp = passedRecord.Value;
        return temp;
    }
    public class DataType
    {
        public int Value { get; set; }
    }

    public enum OrderType
    {
        ASC,
        DESC
    }
    public class MyClass
    {
        private Dictionary<OrderType, string> MyDictionary= new Dictionary<OrderType, string>()
                                                         {
                                                             {OrderType.ASC, ""},
                                                             {OrderType.DESC, ""},
                                                         };
    }

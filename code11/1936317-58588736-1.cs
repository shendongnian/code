    public class Service1 : IService1
        {
            public string GetData(string value)
            {
                return DateTime.Now.ToLongTimeString();
            }
    }

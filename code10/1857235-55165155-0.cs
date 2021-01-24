    public class ServiceA : IService
        {
            public bool withDecs { get; set; } = true;
            public string DoStuff()
            {
                return "ServiceA";
            }
        }

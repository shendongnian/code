        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            string GetData(int value);
    }
        public class Service1 : IService1
        {
            public string GetData(int value)
            {
                return string.Format("You entered: {0}", value);
            }
    }

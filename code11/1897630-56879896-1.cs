            [ServiceContract]
            public interface IService1
            {
                [OperationContract]
                [WebGet(RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]                    
                string GetData(int value);
        
        }

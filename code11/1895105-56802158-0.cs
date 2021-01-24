    class Program
        {
            static void Main(string[] args)
            {
    
                using (ServiceHost sh=new ServiceHost(typeof(MyService)))
                {
                    sh.Open();
                    Console.WriteLine("service is ready....");
    
                    Console.ReadLine();
                    
                    sh.Close();
                }
            }
        }
        [ServiceContract]
        interface IService
        {
            [OperationContract]
            void WriteMessageHeader();
        }
        public class MyService : IService
        {
            public void WriteMessageHeader()
            {
                OperationContext oc = OperationContext.Current;
                //output the SOAP Message Header.
                for (int i = 0; i < oc.IncomingMessageHeaders.Count; i++)
                {
                    MessageHeaderInfo info = oc.IncomingMessageHeaders[i];
                    Console.WriteLine("Name: "+info.Name);
                    Console.WriteLine("Namespace: "+info.Namespace);
                    Console.WriteLine("Content: "+oc.IncomingMessageHeaders.GetHeader<string>(i));
    
                }
            }
    }

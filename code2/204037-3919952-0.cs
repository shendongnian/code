    namespace WcfClient
    {
    class Program
    {
        static IAsyncResult ar;
        static Service1Client client;
        static void Main(string[] args)
        {
            client = new Service1Client();
            try
            {
                ar = client.BeginGetData(2, new AsyncCallback(myCallback), null);
                ar.AsyncWaitHandle.WaitOne();
                ar = client.BeginGetDataUsingDataContract(null, new AsyncCallback(myCallbackContract), null);
                ar.AsyncWaitHandle.WaitOne();
            }
            catch (Exception ex1)
            {
                Console.WriteLine("{0}", ex1.Message);
            }
            Console.ReadLine();
        }
        static void myCallback(IAsyncResult arDone)
        {
            Console.WriteLine("{0}", client.EndGetData(arDone));
        }
        static void myCallbackContract(IAsyncResult arDone)
        {
            try
            {
                Console.WriteLine("{0}", client.EndGetDataUsingDataContract(arDone).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
    }

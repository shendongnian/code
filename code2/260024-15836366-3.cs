    namespace Tester
    {
        class Program
        {
            static void Main(string[] args)
            {
                #region [ Paket Data]
                 ...
                #endregion
    
                for (int i = 0; i < 20; i++)
                {
                    Packet packet = new Packet() { Data = data, Host = "www.google.com.tr", Port = 80, Id = i };
                    SocketManager sm = new SocketManager() { packet = packet };
    
                   <b> ThreadExecuter<packet> te = new ThreadExecuter<packet>(sm.Send, writeScreen);
                    te.Start();</packet></packet></b>
                }
    
                Console.WriteLine("bitti.");
                Console.ReadKey();
            }
    
            private static void writeScreen(Packet p)
            {
                Console.WriteLine(p.Id + " - " + p.Status.ToString());
            }
        }
    }
     

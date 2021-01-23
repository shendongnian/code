    class Program
    {
    static void Main(string[] args)
    {
        for(int i = 0; i < 15; i++)
        {
            using Service1Client client = new Service1Client()
            {
            try
            {
                client.GetData(100);                   
            }
            catch (TimeoutException timeoutEx)
            {
                Console.WriteLine(timeoutEx);
                client.Abort();
            }
            catch (FaultException faultEx)
            {
                Console.WriteLine(faultEx);
                client.Abort();
            }
            catch (CommunicationException commEx)
            {
                Console.WriteLine(commEx);
                client.Abort();
            }
            finally
            {
                client.Close();
            }
            }
      }  
    }              

    class Program {
        static void Main(string[] args) {
            Action action = BeginCheckExc;
            IAsyncResult result = action.BeginInvoke(new AsyncCallback(EndCheckExc), null);
    
            try {
                action.EndInvoke(result);
            }
            catch (Exception ex) { // Exception is caught here
                Console.WriteLine(ex.Message);
            }
        }
    
        static void BeginCheckExc() {
            Thread.Sleep(3000); // Simulate long operation
            throw new Exception("Oops! Something broke!");
        }
    
        static void EndCheckExc(IAsyncResult result) {
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

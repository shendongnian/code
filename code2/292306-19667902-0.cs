    delegate string SynchOperation(string value);
    class Program
    {
        static void Main(string[] args)
        {
            BeginTheSynchronousOperation(CallbackOperation, "my value");
            Console.ReadLine();
        }
        static void BeginTheSynchronousOperation(AsyncCallback callback, string value)
        {
            SynchOperation op = new SynchOperation(SynchronousOperation);
            op.BeginInvoke(value, callback, op);
        }
        static string SynchronousOperation(string value)
        {
            Thread.Sleep(10000);
            return value;
        }
        static void CallbackOperation(IAsyncResult result)
        {
            // get your delegate
            var ar = result.AsyncState as SynchOperation;
            // end invoke and get value
            var returned = ar.EndInvoke(result);
            Console.WriteLine(returned);
        }
    }

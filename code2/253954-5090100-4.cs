    public class Test
    {
        private int WorkerFunction(string a, string b)
        {
            //this is the guy that is supposed to do the long running work 
            Console.WriteLine(a);
            Console.WriteLine(b);
            return a.Length + b.Length;
        }
    
        private void MyCallBack(IAsyncResult ar)
        {
            Func<string, string, int> function = ar.AsyncState as Func<string, string, int>;
            int result = function.EndInvoke(ar);
            Console.WriteLine("Result is {0}", result);
        }
        public void CallMethod()
        {
            Func<string, string, int> function = new Func<string, string, int>(WorkerFunction);
            IAsyncResult result = function.BeginInvoke("param1", "param2", MyCallBack, function);
        }
    
    
    }
    
    class Program
    {
    
        static void Main(string[] args)
        {
            Test test = new Test();
            test.CallMethod();
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace TestAsync
    {
        class Program
        {
            private static Wrapper test = new Wrapper();
    
            static void Main(string[] args)
            {
                test.BeginMethod("parameter 1", "parameter 2", Callback);
                Console.ReadKey();
            }
    
            private static void Callback(IAsyncResult ar)
            {
                string result = test.EndMethod(ar);
                Console.WriteLine(result);
            }
        }
    
        public interface ITest
        {
            IAsyncResult BeginMethod(string s1, string s2, AsyncCallback cb, object state);
            string EndMethod(IAsyncResult result);
        }
    
        public class Wrapper
        {
            private ITest proxy = new Test();
    
            public void BeginMethod(string s1, string s2, AsyncCallback cb)
            {
                proxy.BeginMethod(s1, s2, cb, proxy);
            }
    
            public string EndMethod(IAsyncResult result)
            {
                return ((ITest)(result.AsyncState)).EndMethod(result);
            }
        }
    
        public class Test : ITest
        {
            Func<string, string, string> _delgateObject;
            private string WorkerFunction(string a, string b)
            {
                // "long running work"
                return a + "|" + b;
            }
    
            public IAsyncResult BeginMethod(string s1, string s2, AsyncCallback cb, object state)
            {
                Func<string, string, string> function = new Func<string, string, string>(WorkerFunction);
                this._delgateObject = function;
                IAsyncResult result = function.BeginInvoke(s1, s2, cb, state);
                return result;
            }
    
            public string EndMethod(IAsyncResult result)
            {
                Test test = result.AsyncState as Test;
                return test._delgateObject.EndInvoke(result);
            }
        }
    
        public delegate TResult Func<T1, T2, TResult>(T1 t1, T2 t2);
    }

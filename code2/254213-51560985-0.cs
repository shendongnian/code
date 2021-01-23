    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        public static class AsyncHelper
        {
            private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
    
            public static void RunSync(Func<Task> func)
            {
                _myTaskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
            }
    
            public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            {
                return _myTaskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
            }
        }
    
        class SomeClass
        {
            public async Task<object> LoginAsync(object loginInfo)
            {
                return await Task.FromResult(0);
            }
            public object Login(object loginInfo)
            {
                return AsyncHelper.RunSync(() => LoginAsync(loginInfo));
                //return this.LoginAsync(loginInfo).Result.Content;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var someClass = new SomeClass();
    
                Console.WriteLine(someClass.Login(1));
                Console.ReadLine();
            }
        }
    }

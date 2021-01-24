    using System.Threading;
    using System.Threading.Tasks;
    namespace MyWorkspace
    {
        public class ClassA
        {
            private static readonly ClassX _singletonX = new ClassX();
            public void MyMethod()
            {
                var token1 = new CancellationToken();
                Task.Factory.StartNew(() => _singletonX.MethodY(), token1, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }
        public class ClassX
        {
            public void MethodY()
            {
            }
        }
    }

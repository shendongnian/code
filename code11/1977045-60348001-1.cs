    public class Program {
        public static async Task Main() {
            Console.WriteLine("Hello World");
            await new Program().APIMethod();
        }
        public async Task APIMethod() {
            var cts = new CancellationTokenSource();
            var tasks = new[] { CheckOne(cts.Token), CheckTwo(cts.Token), CheckThree(cts.Token) };
            var running = tasks.ToList();            
            while (running.Count > 0) {
                var finishedTask = await Task.WhenAny(running);
                //remove completed task
                running.Remove(finishedTask);
                Console.WriteLine($"ID={finishedTask.Id}, Result={finishedTask.Result}");
                var result = await finishedTask;
                if (result == CustomStatusCode.Success) { //On first Success                    
                    cts.Cancel(); //ignore the result of the rest of the tasks 
                    break; //and continue
                }
            }
            // If none of them succeed, throw exception; 
            if (running.Count == 0)
                throw new InvalidOperationException();
            //Core Business logic....
            foreach (var t in running) {
                Console.WriteLine($"ID={t.Id}, Result={t.Result}");
            }
        }
   
        public async Task<CustomStatusCode> CheckOne(CancellationToken cancellationToken) {
            await Task.Delay(1000);
            if (cancellationToken.IsCancellationRequested)
                return CustomStatusCode.Canceled;
            return CustomStatusCode.Success;
        }
        public async Task<CustomStatusCode> CheckTwo(CancellationToken cancellationToken) {
            await Task.Delay(500);
            if (cancellationToken.IsCancellationRequested)
                return CustomStatusCode.Canceled;
            return CustomStatusCode.Fail;
        }
        public async Task<CustomStatusCode> CheckThree(CancellationToken cancellationToken) {
            await Task.Delay(1500);
            if (cancellationToken.IsCancellationRequested)
                return CustomStatusCode.Canceled;
            return CustomStatusCode.Fail;
        }
    }
    public enum CustomStatusCode {
        Fail,
        Success,
        Canceled
    }

    public class Program {
        public static async Task Main() {
            Console.WriteLine("Hello World");
            await new Program().APIMethod();
        }
        public async Task APIMethod() {
            var cts = new CancellationTokenSource();
            var tasks = new[] { CheckOne(cts.Token), CheckTwo(cts.Token), CheckThree(cts.Token) };
            var failCount = 0;
            var runningTasks = tasks.ToList();            
            while (runningTasks.Count > 0) {
                //As tasks complete
                var finishedTask = await Task.WhenAny(runningTasks);
                //remove completed task
                runningTasks.Remove(finishedTask);
                Console.WriteLine($"ID={finishedTask.Id}, Result={finishedTask.Result}");
                //process task (in this case to check result)
                var result = await finishedTask;
                //perform desired logic
                if (result == CustomStatusCode.Success) { //On first Success                    
                    cts.Cancel(); //ignore the result of the rest of the tasks 
                    break; //and continue
                }
                failCount++;
            }
            // If none of them succeed, throw exception; 
            if (failCount == tasks.Length)
                throw new InvalidOperationException();
            //Core Business logic....
            foreach (var t in runningTasks) {
                Console.WriteLine($"ID={t.Id}, Result={t.Result}");
            }
        }
   
        public async Task<CustomStatusCode> CheckOne(CancellationToken cancellationToken) {
            await Task.Delay(1000); // mimic doing work
            if (cancellationToken.IsCancellationRequested)
                return CustomStatusCode.Canceled;
            return CustomStatusCode.Success;
        }
        public async Task<CustomStatusCode> CheckTwo(CancellationToken cancellationToken) {
            await Task.Delay(500); // mimic doing work
            if (cancellationToken.IsCancellationRequested)
                return CustomStatusCode.Canceled;
            return CustomStatusCode.Fail;
        }
        public async Task<CustomStatusCode> CheckThree(CancellationToken cancellationToken) {
            await Task.Delay(1500); // mimic doing work
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

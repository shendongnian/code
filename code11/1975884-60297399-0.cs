    namespace Test {
    public class Program {
        public static void Main() {
            System.Threading.Thread main = new System.Threading.Thread(() => new Processor().Startup());
            main.IsBackground = false;
            main.Start();
            System.Console.ReadKey();
        }
    }
    public class ProcessResult { /* add your result state */ }
    public class ProcessState {
        public ProcessResult ProcessResult1 { get; set; }
        public ProcessResult ProcessResult2 { get; set; }
        public ProcessResult ProcessResult3 { get; set; }
        public string State { get; set; }
    }
    public class Processor {
        private readonly object _Lock = new object();
        private readonly DataFetcher _DataFetcher;
        private ProcessState _ProcessState;
        public Processor() {
            _DataFetcher = new DataFetcher();
            _ProcessState = null;
        }
        public void Startup() {
            _DataFetcher.DataChanged += DataFetcher_DataChanged;
        }
        private void DataFetcher_DataChanged(object sender, DataEventArgs args) => StartProcessingThreads(args.Data);
        private void StartProcessingThreads(string data) {
            lock (_Lock) {
                _ProcessState = new ProcessState() { State = "Starting", ProcessResult1 = null, ProcessResult2 = null, ProcessResult3 = null };
                System.Threading.Thread one = new System.Threading.Thread(() => DoProcess1(data)); // manipulate the data toa subset 
                one.IsBackground = true;
                one.Start();
                System.Threading.Thread two = new System.Threading.Thread(() => DoProcess2(data)); // manipulate the data toa subset 
                two.IsBackground = true;
                two.Start();
                System.Threading.Thread three = new System.Threading.Thread(() => DoProcess3(data)); // manipulate the data toa subset 
                three.IsBackground = true;
                three.Start();
            }
        }
        public ProcessState GetState() => _ProcessState;
        private void DoProcess1(string dataSubset) {
            // do work 
            ProcessResult result = new ProcessResult(); // this object contains the result
            // on completion
            lock (_Lock) {
                _ProcessState = new ProcessState() { State = (_ProcessState.State ?? string.Empty) + ", 1 done", ProcessResult1 = result, ProcessResult2 = _ProcessState?.ProcessResult2, ProcessResult3 = _ProcessState?.ProcessResult3 };
            }
        }
        private void DoProcess2(string dataSubset) {
            // do work 
            ProcessResult result = new ProcessResult(); // this object contains the result
            // on completion
            lock (_Lock) {
                _ProcessState = new ProcessState() { State = (_ProcessState.State ?? string.Empty) + ", 2 done", ProcessResult1 = _ProcessState?.ProcessResult1 , ProcessResult2 = result, ProcessResult3 = _ProcessState?.ProcessResult3 };
            }
        }
        private void DoProcess3(string dataSubset) {
            // do work 
            ProcessResult result = new ProcessResult(); // this object contains the result
            // on completion
            lock (_Lock) {
                _ProcessState = new ProcessState() { State = (_ProcessState.State ?? string.Empty) + ", 3 done", ProcessResult1 = _ProcessState?.ProcessResult1, ProcessResult2 = _ProcessState?.ProcessResult2, ProcessResult3 = result };
            }
        }
    }
    public class DataEventArgs : System.EventArgs {
        // data here is string, but could be anything -- just think of thread safety when accessing from the 3 processors
        private readonly string _Data;
        public DataEventArgs(string data) {
            _Data = data;
        }
        public string Data => _Data;
    }
    public class DataFetcher {
        //  watch for data changes and fire when data has changed
        public event System.EventHandler<DataEventArgs> DataChanged;
    }
}

    public class Sequence {
            EventWaitHandle handle = new EventWaitHandle(false, EventResetMode.ManualReset);
            public async Task Tsk1() {
                
                Console.WriteLine("Did some work from tsk1");
                handle.Set();
                
            }
            public async Task Tsk2() {
                handle.WaitOne();
                Console.WriteLine("Doing work after tsk1 finished");
                //do some other stuff
            }
        }
        class Program {
            static async Task Main(string[] args) {
               
                    Sequence seq = new Sequence();
                    var t2 =Task.Run(seq.Tsk2);
                    var t1 =Task.Run(seq.Tsk1);
    
                    await Task.WhenAll(t1, t2);
                    Console.WriteLine("finished both");
            }
        }

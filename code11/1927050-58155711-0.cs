    namespace ConsoleApplication1
    {
        public class State
        {
            public List<string> data { get; set; }
        }
         
        public class MyBackgroundWorker
        {
            public static BackgroundWorker backgroundWorker1 = new BackgroundWorker();
            public void Test()
            {
                State state = new State();
                state.data = new List<string> { "Some Data" };
                int progress = 50;
                backgroundWorker1.ReportProgress(progress, state);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
            }
            private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                State state = e.UserState as State;
                //add code to write to datatable here
            }
        }
    }

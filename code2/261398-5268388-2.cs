    public class Test
    {
        private readonly WebBrowser wb;
        public Test()
        {
            wb = new WebBrowser();
            var bw = new BackgroundWorker();
            bw.DoWork += DoWork;
            bw.RunWorkerAsync();
            while (bw.IsBusy)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            } 
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            wb.Navigate(@"www.clix-cents.com/pages/clickads");
            Thread.Sleep(1000);
            var regex = new Regex("onclick=\\'openad\\(\"([\\d\\w]+\"\\);");
            regex.IsMatch(wb.DocumentText);
        }
    }
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Test();
        }
    }

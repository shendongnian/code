    public partial class Service1 : ServiceBase
    {
        Timer timer1 = new Timer();
        string filePath = @"C:\Users\Test\Desktop\New folder\Test.txt";
        string logPath = @"C:\Users\Test\Desktop\New folder\Log.txt";
        string newLog = @"C:\Users\Test\Desktop\New folder\Log1.txt";
        long oldFileSize; // Add this line
        public void OnStart(string[] args)
        {            
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 60000;
            timer1.Enabled = true;
            timer1.AutoReset = true;
            timer1.Start();
            FileInfo f = new FileInfo(filePath);
            oldFileSize = f.Length; // change this line
            using (StreamWriter file = new StreamWriter(logPath))
            {
                file.WriteLine(s1.ToString());
            }
        }
        public void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            FileInfo f = new FileInfo(filePath);
            long s2 = f.Length;
  
            using (StreamWriter file = new StreamWriter(newLog))
            {
                if (s2 == oldFileSize)
                {
                    // Send Email
                }
                file.WriteLine(s2.ToString());
            }
        }

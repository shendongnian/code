    //code behind
    protected void butRefreshData_Click(object sender, EventArgs e)
    {
        Thread t = new Thread(new ThreadStart(DataRepopulater.DataRepopulater.RepopulateDatabase));
        t.Start();       
    }
    //DataRepopulater.cs
    namespace DataRepopulater
    {
        public static class DataRepopulater
        {
        private static string myLock = "My Lock";
        public static void RepopulateDatabase()
        {
            if(Monitor.TryEnter(myLock))
            {
                DoWork();
                Monitor.Exit(myLock);
            }
        }
    }

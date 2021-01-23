    class BaseCheck
    {
        private DateTime Started { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime LastRun { get; set; }
        public int Runs { get; set; }
        //Others
        public void RunCheck()
        {
            if (Started != null)
                Started = DateTime.Now;
            LastRun = DateTime.Now;
            Runs++;
            CoreRun();
        }
        protected virtual void CoreRun()
        {
        }
    }
    public class DirectoryCheck : BaseCheck
    {
        public string DirectoryName { get; set; }
        protected override void CoreRun()
        {
            //I want all the code in the base class to run plus
            //any code I put here when calling this class method
            Console.WriteLine("From DirectoryCheck");
        }
    }

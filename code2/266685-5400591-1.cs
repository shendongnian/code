    public class DirectoryCheck : baseCheck
    {
        public string DirectoryName { get; set; }
        public void RunCheck()
        {
            //I want all the code in the base class to run plus
            //any code I put here when calling this class method
            base.RunCheck();
            Console.WriteLine("From DirectoryCheck");
        }
    }

    internal class MyReportGenerator
    {
        // Private member variables
        private int someVar;
        // Public properties
        public string TypeOfReport { get; set; }
        // Constructor
        public MyReportGenerator(string s, int i)
        {
            // Here you can initialize your member variables
        }
        // Methods
        void GenerateReport(string otherParams)
        {
        }
        public static void Main(string[] args)
        {
            // Setup the report generator, scheduler, etc
            MyReportGenerator generator = new MyReportGenerator(...);
            generator.GenerateReport(...);
        }
    }

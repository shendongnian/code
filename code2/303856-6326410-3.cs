    <!-- language: lang-cs -->
        [STAThread]
        public static void Main()
        {
            try
            {
                MyMethod();
            }
            catch(Exception e)
            {
                // ... Write to file here
            }
        }
        
        private static void MyMethod()
        {
            // .. Do actual work here
        }
    

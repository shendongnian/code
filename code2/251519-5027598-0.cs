        class Program
        {
            static void Main(string[] args)
            {
                string[] Values = {"123", "someword", "12yu", "123.56" };
                foreach(string val in Values)
                    Console.WriteLine(string.Format("'{0}' - Is number?: {1}",val, val.IsNumber()));
            }
        }
    
        
        public static class StringExtension
        {        
            public static bool IsNumber(this String str)
            {
                double Number;
                if (double.TryParse(str, out Number)) return true;
                return false;            
            }
        }

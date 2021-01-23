    using System;
    
    public static class Test
    {
        public static void Main()
        {
            string input = "<span style=\"cursor: pointer;\">$$</span>";
            string[] bits = input.Split(new string[]{"$$"},
                                        StringSplitOptions.None);
            
            foreach (string bit in bits)
            {
                Console.WriteLine(bit);
            }
        }    
    }

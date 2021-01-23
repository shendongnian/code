    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class MainClass {
        public static void Main() {
            string[] words = { "cherry", "apple", "blueberry" };
    
            int longestLength = words.Max(w => w.Length);
    
            Console.WriteLine("The longest word is {0} characters long.", longestLength);
        }
    }

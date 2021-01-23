    using System;
    using System.Text;
    using System.Collections.Generic;
    
    class Program {
        static void Main() {
            byte[] bytes = { 32, 32, 32, 10 };
            string text  = "hello\n";
    
            if (HasUnixNewline(Encoding.ASCII.GetChars(bytes))) {
                Console.WriteLine("Found Unix newline in 'bytes'.");
            }
            if (HasUnixNewline(text)) {
                Console.WriteLine("Found Unix newline in 'text'.");
            }
       }
    
        static bool HasUnixNewline(IEnumerable<char> chars) {
    		bool prevIsCR = false;
    		foreach (char ch in chars) {
    			if ((ch == '\n') && (!prevIsCR)) {
    				return true;
    			}
    			prevIsCR = ch == '\r';
    		}
            return false;
        }
    }

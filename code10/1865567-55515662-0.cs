    using System;
    using System.Text;
    
    namespace Rextester
    {
    
        public class Program
        {
            public static void Main()
            {
                string input = "aSd2&5s@1";
                char[] inputArray = input.ToCharArray();
                string output = "";
    
                string ab = "";
                foreach (char c in inputArray)
                {
                    int x;
                    string y;
                    if(int.TryParse(c.ToString(), out x))
                    {
                        y = GetString(ab, x);
    					ab = "";
    					output += y;
                    }
                    else
                    {
    					ab += c;
                        y = ab.ToUpper();
                    }
                }
                Console.WriteLine(output);
            }
    
            static string GetString(string a, int b)
            {
    			string sb = "";
                for(int i=0;i<b;i++)
                {
                    sb+=a;
                }
                return sb.ToUpper();
            }
        }
    
    }

    namespace RemoveChars
    {
        class Program
        {
            static string str = @"this ' is a\“ cra@zy: me|ssage/ an-d I& want#to clea*n it";
    
            static void Main(string[] args)
            {
                CleanMyString(str);
            }
    
            public static void CleanMyString(string myStr)
            {
                string myCrazyString  = @":|/-\“‘&*#@";
                var result = "";
                foreach (char c in myStr)
                {
                    var t = true; // t will remain true if c is not a crazy char
                    foreach (char ch in myCrazyString)
                        if (c == ch)
                        {
                            t = false;
                            break;
                        }
                    if (t)
                        result += c;
                }
            } 
        }
    }

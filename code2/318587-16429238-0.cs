    static void Main(string[] args)
            {
    
                string s1 = null;
                string s2 = string.Empty;
                string s3 = "";
                Console.WriteLine(s1 == s2);
                Console.WriteLine(s1==s3);
                Console.WriteLine(s2==s3);
            }
    
     results:
     false     - since null is different from string.empty
     false     - since null is different from ""
     true      - since "" is same as string.empty

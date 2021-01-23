    class Program
        {
            static void Test(Func<string, bool> f, string s)
            {
                f.Invoke(s);
            }
    
            static bool GetItem(string s)
            {
                Console.WriteLine("getItem");
                if (s == "123") return true;
                else return false;
            }
    
            static void Main(string[] args)
            {
                Test(GetItem, "Test String");
    
                
            }

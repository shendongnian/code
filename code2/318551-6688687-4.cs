    namespace ConsoleApplication2
    
    {
    
        using System;
    
        using ConsoleApplication3;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                ThirdPartyClass t = new ThirdPartyClass();
                Console.WriteLine(t.Fun("hh"));
                Console.WriteLine(t.Fun(1));
            }
        }
    
    
        public static class LocalExtension
        {
            public static string Fun(this ThirdPartyClass test, int val)
            {
                return "Local" + val;
            }
    
            public static string Fun(this ThirdPartyClass test, string val)
            {
                return "Local" + val;
            }
        }
    }
    
    
    namespace ConsoleApplication3
    
    {
    
        public class ThirdPartyClass
        {
            public virtual string Fun(string val)
            {
                return "ThirdParty" + val.ToUpper();
            }
        }
    
    
        public static class ThripartyExtension
        {
            public static string Fun(this ThirdPartyClass test, int val)
            {
                return "ThirdParty" + val;
            }
        }
    }

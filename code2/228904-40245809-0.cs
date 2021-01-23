    namespace SomeLogic1
    {
        public static class Util
        {
            public static int Bar1()
            {
                return 1;
            }
        }
    }
    namespace SomeLogic2
    {
        public static class Util
        {
            public static int Bar2()
            {
                return 2;
            }
        }
    }
    namespace GeneralStuff
    {
        using SomeLogic1;
        using SomeLogic2;
    
        public class MainClass
        {
            public MainClass()
            {
                // Error CS0104
                // 'Util' is an ambiguous reference between 'SomeLogic1.Util' and 'SomeLogic2.Util'
                var result = Util.Bar1() + Util.Bar2(); 
            }
        }
    }  

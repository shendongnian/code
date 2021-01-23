    namespace Foo
    {
        using SV = Common.SessionVariables;
    
        public class Common
        {
            public struct SessionVariables
            {
                public static string IsLogout = "IsLogout";
            }
        }
        public class Example
        {
            public void Bar()
            {
                string test = SV.IsLogout;
            }
        }
    }

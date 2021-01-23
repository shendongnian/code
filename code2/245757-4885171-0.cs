    namespace ConsoleApplication1
    {
        public static class ObjectExtensions
        {
            public static string AsString(this object source)
            {
                if (source != null)
                {
                    return source.ToString();
                }
                else
                {
                    return null;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                object a = null;
                object b = "not null";
    
                string someText = a.AsString();
            }
        }
    }

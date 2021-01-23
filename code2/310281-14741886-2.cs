    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myReplacement = "4";
                StringBuilder temp = new StringBuilder();
                string str = "/a/b/1/cdd/d.jpg";
                string[] splitArray = new string[] { "/" };
                string[] split = str.Split(splitArray,StringSplitOptions.RemoveEmptyEntries );
                if (split.Length > 1)
                    split[2] = myReplacement;
                str = "/" + string.Join("/", split);     
            }
        }
    }

    using System;
    using System.Web;
    
    namespace ConsApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                int lp = 0;
                string[] Inputs = {"\U00024859", "<tag>\U00024859<\\tag>"};
                foreach (var Test in Inputs)
                {
                    string HTML = HttpUtility.HtmlEncode(Test);
                    Console.WriteLine(String.Format(HTML != Test ? "String {0} Changed" : "String {0} Unchanged", lp));
                    lp++;
                }
            }
        }
    }

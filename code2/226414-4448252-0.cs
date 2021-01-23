    class Program
    {
        static void Main()
        {
            var assembly = Assembly.Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            var serverType = assembly.GetType("System.Web.HttpUtility", true);
            var method = serverType.GetMethod("HtmlEncode", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string) }, null);
            var result = method.Invoke(null, new[] { "<some value>" });
            Console.WriteLine(result);
        }
    }

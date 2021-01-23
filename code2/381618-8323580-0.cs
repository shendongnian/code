    using System;
    using System.IO;
    using Noesis.Javascript;
    
    class Program
    {
        static void Main()
        {
            var context = new JavascriptContext();
            context.SetParameter("openid", new object());
            context.Run(File.ReadAllText("test.js"));
            dynamic providers_large = context.GetParameter("providers_large");
            foreach (var provider in providers_large)
            {
                Console.WriteLine(
                    "name: {0}, url: {1}", 
                    provider.Value["name"], 
                    provider.Value["url"]
                );
            }
        }
    }

            var classLibrary1AppSettings = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationManager.GetSection("classLibrary1");
            Console.WriteLine(classLibrary1AppSettings["Value1"]);
            Console.WriteLine(classLibrary1AppSettings["Value2"]);
            Console.WriteLine(classLibrary1AppSettings["Value3"]);
            var classLibrary2AppSettings = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationManager.GetSection("classLibrary2");
            Console.WriteLine(classLibrary2AppSettings["Value1"]);
            Console.WriteLine(classLibrary2AppSettings["Value2"]);
            Console.WriteLine(classLibrary2AppSettings["Value3"]);

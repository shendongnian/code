            StreamReader streamReader = new StreamReader("test.js");
            string script = streamReader.ReadToEnd();
            streamReader.Close();
            JintEngine js = new JintEngine();
            js.Run(script);
            object result = js.Run("return status;");
            Console.WriteLine(result);
            Console.ReadKey();

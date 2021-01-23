    JintEngine js = new JintEngine();
    string jstr = System.IO.File.ReadAllText(test.js);
    js.Run(jstr);
    object result = js.Run("return status;");
    Console.WriteLine(result);
    Console.ReadKey();

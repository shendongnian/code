        List<string> myArgs = new List<string>();
        myArgs.Add("test\"123"); // test"123
        myArgs.Add("test\"\"123\"\"234"); // test""123""234
        myArgs.Add("test123\"\"\"234"); // test123"""234
        string cmargs = BuildCommandLineArgs(myArgs);
        // result: ""test\"123"" ""test\"\"123\"\"234"" ""test123\"\"\"234""
        
        // when you pass this result to your app, you will get this args list:
        // test"123
        // test""123""234
        // test123"""234

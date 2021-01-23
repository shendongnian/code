        string message = "test of mine";
        string[] keys = new string[] {"test2",  "test"  };
        string sKeyResult = keys.FirstOrDefault<string>(s=>message.Contains(s));
        switch (sKeyResult)
        {
            case "test":
                Console.WriteLine("yes for test");
                break;
            case "test2":
                Console.WriteLine("yes for test2");
                break;
        }

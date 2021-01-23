    switch(message)
    {
      case "test":
        Console.WriteLine("yes");
        break;                
      default:
        if (Contains("test2")) {
          Console.WriteLine("yes for test2");
        }
        break;
    }

    public string GetCustomUI(string ribbonID)
    {
      if (ribbonID == "Microsoft.Outlook.Explorer")
        return GetResourceText("testingOLaddin2.Ribbon1.xml");
      
      return null; // if problems here, try return string.Empty
    }

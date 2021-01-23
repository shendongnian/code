    string majorVersionString = Globals.ThisAddIn.Application.Version.Split(new char[] { '.' })[0];
    int majorVersion = Convert.ToInt32(majorVersionString);
    if (majorVersion < 14)
    {
        //Register CommandBar
    }

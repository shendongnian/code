    public void Session()
    {
        // Create a list of all Data Types.
        DataTypes = new List<string>();
        DataTypes.Add("DataInfo");
        DataTypes.Add("Maps"); 
        DataTypes.Add("Tilesets");
        // Create and populate TempData dictionary.
        TempData = new Dictionary<string, Dictionary<string, object>>();
        TempData.Add("DataInfo", new Dictionary<string, object>());
        TempData.Add("Maps", new Dictionary<string, object>());
        TempData.Add("Tilesets", new Dictionary<string, object>());
        // Create GameData dictionary and copy TempData into it.
        GameData = new Dictionary<string, Dictionary<string, object>>(TempData);
    }

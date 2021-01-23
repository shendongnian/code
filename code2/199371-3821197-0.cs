    string[] colorNames  = System.Enum.GetNames(typeof(KnownColor));
    foreach(string colorName in colorNames)
    {
      Color color = Color.FromName(colorName);
    }

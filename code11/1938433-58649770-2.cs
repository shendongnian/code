    public static Dictionary<ColorBox, ColorDictionary> CreateComboTable() 
    {
       var table = new Dictionary<ColorBox, ColorDictionary>();
       table[ColorBox.Blue | ColorBox.White] = ColorDictionary.muddyWater;
       // And so on...
       return table;
    }

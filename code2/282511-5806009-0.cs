    private List<string> GetColors()
    {
        //create a generic list of strings
        List<string> colors = new List<string>();
        //get the color names from the Known color enum
        string[] colorNames = Enum.GetNames(typeof(KnownColor));
        //iterate thru each string in the colorNames array
        foreach (string colorName in colorNames)
        {
            //cast the colorName into a KnownColor
            KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
            //check if the knownColor variable is a System color
            if (knownColor > KnownColor.Transparent)
            {
                //add it to our list
                colors.Add(colorName);
            }
        }
        //return the color list
        return colors;
    }

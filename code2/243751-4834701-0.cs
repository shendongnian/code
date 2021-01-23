         List<string> colors = new List<string>();
       
        foreach (string colorName in Enum.GetNames(typeof(KnownColor)))
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

    foreach(var items in output)
    {
        var newColor = new Color
        {
            ColorId = items.ColorId,
            ColorName = items.ColorName,
            shortName = items.ShortName,
        };
        color.Add(newColor);
        
        // some other codes 
        // .........
        index++;       // this is to insert values to list during another (second loop) of foreach statement above
    
    }

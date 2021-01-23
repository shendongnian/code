    string closestColor = "";
    double diff = 200000; // > 255²x3
    
    foreach(string colorHex in validColors)
    {
        Color color = System.Drawing.ColorTranslator.FromHtml("#"+colorHex);
        if(diff <= (diff = (c.R - color.R)²+(c.G - color.G)²+(c.B - color.B)²))
            closestColor = colorHex;
    }
    
    return closestColor;

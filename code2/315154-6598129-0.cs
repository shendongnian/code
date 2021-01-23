    for (int j = 0; j < first.Height; 
    {
        Color secondColor = second.GetPixel(i, j);
        Color firstColor = first.GetPixel(i, j);
    
        if (firstColor != secondColor)
        {
            DiferentPixels++;
            container.SetPixel(i, j, Color.Red);
        }
        else
        {
            container.SetPixel(i, j, firstColor);
        }
    }

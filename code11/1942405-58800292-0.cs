    List<Color> colors = new List<Color>();
    foreach(var items in output)
    {
      Color col = new Color();
      col.ColorId = items.ColorId;       
      col.ColorName = items.ColorName;
      col.ShortName = items.ShortName;
      // .........
      colors.Add(col);
    }

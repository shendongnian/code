    List<Color> colorList = new List<Color>();
    Color color;
    foreach(var item in output)
    {
       color = new Color();
       color.ColorId = item.ColorId;       
       color.ColorName = item.ColorName;
       color.ShortName = item.ShortName;
       colorList.Add(color); 
    }

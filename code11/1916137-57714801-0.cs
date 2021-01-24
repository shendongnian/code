    public void heightline()
    {
    	List<UIElement> uIElements = mycanvas.Children.Cast<UIElement>().ToList();
    
    	UIElement heightline = uIElements.Where(p => p.Uid == "myLine").FirstOrDefault();
    
    	if (heightline == null)
    	{
    		heightline = new Line();
    		heightline.Uid = "myLine";
    	}
    
    
            heightline.Stroke = new SolidColorBrush(Colors.SteelBlue);
            heightline.StrokeThickness = 2;
            heightline.X1 = 510;
            heightline.Y1 = 110;
            heightline.X2 = 510;
            heightline.Y2 = 110 + rect.Height;
    
    	if(uIElements.Count == 0)
    	{
    		mycanvas.Children.Add(heightline);
    	}
    }

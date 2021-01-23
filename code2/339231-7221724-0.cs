    public void ChangeColor()  
    {  
       Type type = GetType();  
        PropertyInfo pathInfo = type.GetProperty("AkkarColor");  
        pathInfo.SetValue(this, System.Windows.Media.Brushes.Red, null);  
    }  

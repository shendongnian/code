    string GetColorName(Color color)
    {
    	var colorProperties = typeof(Color)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(p => p.PropertyType == typeof(Color));
    	foreach(var colorProperty in colorProperties) 
    	{
    		var colorPropertyValue = (Color)colorProperty.GetValue(null, null);
    		if(colorPropertyValue.R == color.R 
                   && colorPropertyValue.G == color.G 
                   && colorPropertyValue.B == color.B) {
    			return colorPropertyValue.Name;
    		}
    	}
    	
        //If unknown color, fallback to the hex value
        //(or you could return null, "Unkown" or whatever you want)
    	return ColorTranslator.ToHtml(color);
    }

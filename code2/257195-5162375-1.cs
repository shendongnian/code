        string sType = "System.Int32";//Get your type from attribute 
        string value = "88"; //Get your element 
        
        switch (sType)
        {
            case "System.Int32":
                int i = (int)Convert.ChangeType(value, Type.GetType("System.Int32"), CultureInfo.InvariantCulture);
                break;
            case "System.Drawing.Color" :
                Color c = (Color)Convert.ChangeType(value, Type.GetType("System.Drawing.Color"), CultureInfo.InvariantCulture);
                break;
        }

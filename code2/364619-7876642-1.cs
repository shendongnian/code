    private TextStyle myTextStyle
        {
            get
            {
                var colorName = "Red";
    
                if(!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["myColor"]))
                {
                    colorName = ConfigurationManager.AppSettings["myColor"];
                }
    
                return new TextStyle(new SolidBrush(Color.FromName(colorName)), null, FontStyle.Regular);
            }
        }

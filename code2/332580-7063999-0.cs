    string fontWeight;
    
    public string FontWeight
    { 
        get
        {
            if (string.IsNullOrEmpty(fontWeight))
                fontWeight = "Normal";
            return fontWeight;
        }
        set { fontWeight = value; } 
    }

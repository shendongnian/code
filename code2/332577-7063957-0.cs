    private string fontWeight;
    public String FontWeight 
    { 
        get { String.IsNullOrEmpty(fontWeight) ? "Normal" : fontWeight;}
        set {fontWeight = String.IsNullOrEmpty(value) ? "Normal" : value;} 
    }

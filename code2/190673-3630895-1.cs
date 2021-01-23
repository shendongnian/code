    class Style
    {
       private static readonly Style DefaultStyle = new Style(null) {
           Name = "",
           ... 
       };
       private readonly Style parentStyle;
       private string name;
       public string Name
       {
           get { return name ?? parentStyle.Name); }
           set { name = value; }
       }
       public Style(Style parentStyle)
       {
           this.parentStyle = parentStyle ?? DefaultStyle;
       }
    }

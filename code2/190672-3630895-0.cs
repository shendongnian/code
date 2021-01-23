    class Style
    {
       private readonly Style parentStyle;
       private string name;
       public string Name
       {
           get { return name ?? (parentStyle == null ? null : parentStyle.Name); }
           set { name = value; }
       }
       public Style(Style parentStyle)
       {
           this.parentStyle = parentStyle;
       }
    }

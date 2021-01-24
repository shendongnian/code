    private string mycolor = "Accent";
    
    public string MyColor
    {
       get
       {
          return mycolor;
       }
       set
       {
          if (mycolor != value)
          {
              mycolor = value;
              OnPropertyChanged("MyColor");
          }
        }
     }

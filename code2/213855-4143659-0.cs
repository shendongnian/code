    public MyClass
    {
       public MyDataClass Data{get; set;}
       [DisplayName("ID")]
       public string DataID {
         get {return Data.ID;}
         set {Data.ID = value;}
       }
       [DisplayName("Name")]
       public string DataName {
         get {return Data.Name;}
         set {Data.Name = value;}
       }
    }

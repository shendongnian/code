    [AttributeUsage(AttributeTargets.Class]
    Class SimpleClassName : System.Attribute{
       public string ClassName { get; set; }
    
       SimpleClassName(string _name){
         ClassName = _name;
       }
    
    }

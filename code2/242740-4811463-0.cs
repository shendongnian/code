    public class MyBaseClass
    {
      public virtual DateTime ModifiedTime{ get; set; }
    }
    
    public class Student: MyBaseClass
    {       
      public string Name { get; set; }
      public school MySchool {get;set;} 
      public virtual DateTime ModifiedTime
      { 
        get {
           return MySchool.ModifiedTime;
        }
        set {
           MySchool.ModifiedTime = value;
        }
      }
    }

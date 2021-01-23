    public class Student : BaseClass
    {
       private string _school;
       public String School 
       {
           get { return _school; }
           set {
                _school = value;
                DoMoreChanges(ref _school);  // DoMoreChanges is defined in BaseClass
           }
       }
       public String Country{ get; set; }
    }

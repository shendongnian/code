    public partial class College   
    { 
      public CollegeDetails collegeDetails;
      //Never instantiate
      //public List<Students> students;      
      //Should be:
      public List<Students> students = new List<Students>();
      public StaffDetails staffDetails;   
    } 
    

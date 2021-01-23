    public partial class College   
    { 
      public CollegeDetails CollegeDetails;
      //Never instantiate
      //public List<Students> Students;      
      //Should be:
      public List<Students> Students = new List<Students>();
      public StaffDetails StaffDetails;   
    } 
    

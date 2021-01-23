    public partial class College   
    { 
      public CollegeDetails CollegeDetails;
      //Never instantiate
      //public List<Students> Students;      
      //Should be:
      List<Students> Students = new List<Students>();
      public StaffDetails StaffDetails;   
    } 
    

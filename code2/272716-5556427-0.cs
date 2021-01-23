    public partial class College {
      public College() {
        CollegeDetails = new CollegeDetails();
        Students = new List<Students>();
        StaffDetails = new StaffDetails();
      }
      public CollegeDetails CollegeDetails;
      public List<Students> Students;
      public StaffDetails StaffDetails;
    }
    public partial class Students {
      public Students() {
        StudentDetails = new StudentDetails();
        Marks = new List<Marks>();
      }
      public StudentDetails StudentDetails;
      public List<Marks> Marks;
    }

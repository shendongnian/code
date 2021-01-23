    public class BasePage {
     
      public Menu Menu { get; set; }
    }
    public class StudentPage : BasePage {
      public IEnumerable<Student> Students { get; set; }
    }

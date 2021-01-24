    public class Student : IComparable {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      public string StudentNumber { get; set; }
      public string Gender { get; set; }
      public string FieldOfStudy { get; set; }
      public int CompareTo(object obj) {
        Student that = (Student)obj;
        if (this.LastName.Equals(that.LastName))
          return this.FirstName.CompareTo(that.FirstName);
        return this.LastName.CompareTo(that.LastName);
      }
    }

    public class Participant {
      private static int count = 1;
      public int ID { get; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public List<TimeSpan> LapTimes { get; set; }
      public Participant(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
        ID = count++;
      }
    }

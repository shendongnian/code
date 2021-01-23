    public class User {
      ICollection<FacilityTask> FacilityTask {get; set;}
    }
    public class FacilityTask {
      public Facility Facility {get; set;}
      public Task Task {get; set;}
    }
    or 
    public class FacilityTasks {
      public Facility Facility {get; set;}
      public ICollection<Task> Task {get; set;}
    }

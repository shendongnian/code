        public int ID { get; set; }
       public List<Project> Projects { get; set }
    }
    public class Project
    {
        public int ID { get; set; }
        public List<Task> Tasks { get; set }
    }
    public class Task
    {
        public string details { get; set; }
    }

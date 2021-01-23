    public class Client
	{
        public int Id {get;set;}
        // Client Properties
        private List<Project> _projects = new List<Project>();
        public List<Project> Projects { get { return _projects; } }
	}
    public class Project
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        // Project Properties
        private List<Task> _tasks = new List<Task>();
        public List<Task> Tasks { get { return _tasks; } }
    }
    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        // Task Properties
    }

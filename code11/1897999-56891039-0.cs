    namespace Response
    {
        public class ProjectManager
        {
            public int id { get; set; }
            public int projectId { get; set; }
            public int userId { get; set; }
            public Project project { get; set; }
            public User user { get; set; }
        }
    
        public class Project
        {
            public int id { get; set; }
            public string projectName { get; set; }
            public DateTime plannedStartDate { get; set; }
            public DateTime plannedEndDate { get; set; }
            public object actualStartDate { get; set; }
            public object actualEndDate { get; set; }
            public string projectDescription { get; set; }
            public object[] onProjects { get; set; }
            public object[] projectManagers { get; set; }
        }
    
        public class User
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public bool isProjectManager { get; set; }
            public DateTime registrationTime { get; set; }
            public object employees { get; set; }
            public int id { get; set; }
            public string userName { get; set; }
        }
    }

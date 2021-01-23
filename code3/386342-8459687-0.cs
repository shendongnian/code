    List<Project> cProjects = new List<Project> { new Project(100500) }; 
    public class Project
    {
        public Project(int id)
        {
            this.id = id;
            Subprojects = new List<Subproject> { new Subproject(this) };
        }
        public int id;
        public List<Subproject> Subprojects;
    }
    public class Subproject
    {
        public Subproject(Project project)
        {
            this.Project = project;
        }
        public Project Project;
    }

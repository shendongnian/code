    public class ProjectsContext : IProjectsContext {
        private const string ProjectsCollectionName = "Projects";
        private readonly IMongoDatabase database;
        private IMongoCollection<Project> projects;
    
        public ProjectsContext(IMongoDatabase database) {
            this.database = database;
        }
    
        public IMongoCollection<Project> Projects {
            get {
                if (projects is null)
                    projects = database.GetCollection<Project>(ProjectsCollectionName);
                return projects;
            }
        }
    }

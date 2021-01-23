    public class JStudent
    {
        public List<JProject> projects = new List<JProject>();
        public string name;
        public string id;
    }
    public class JProject
    {
        public List<JTask> tasks = new List<JTask>();
        public string name;
        public string id;
    }
    public class JTask
    {
        public string name;
        public string id;
    }

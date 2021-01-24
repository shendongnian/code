    public class Dependency : IDependency {
    
        public Dependency(HttpClient httpClient) {
          // <snipped>
        }
    }
    public class Job1: IJob {
        public Job1(IDependency dependency) {
          // <snipped>
        }
    }

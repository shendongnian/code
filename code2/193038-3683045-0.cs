    public class MyService : IMyService {
        List<IMyDependency> _myDeps;
    
        [Dependency]
        public IMyDependency[] Deps { 
           set {
              _myDeps = new List<IMyDependency>(Deps);
           }
        }
        ...
    }

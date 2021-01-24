    public class MyRepository : IMyRepository {
        private readonly string _path;
    
        public MyRepository(ISomeSetting setting)  
            _path = setting.Path;
        }
    
        // more code...
    }

    public class BaseService<T> : where T : Base, new() {
        
        private readonly Base _cfg;
        
        public BaseService(IOptions<T> Tcfg) {
            _cfg = Tcfg.Value;
        }
        
        public void Get() {
            
              //works now
              var _id = _cfg.Id;
        }
    }

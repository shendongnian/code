    public class MyClass : IMyClass {
        private readonly ILogger log;
    
        public MyClass(ILogger log) {
            this.log = log;
        }
    
        public virtual bool NeedsMoreWork(Item item, out Part part) { //<-- THIS IS NOW VIRTUAL
            log.Debug($"Examining item {item.Id}");
            part = null;
            if (item.Completed()) {
                log.Debug($"Item {item.Id} already completed.");
                return false;
            }
            part = item.GetNextPart();
            log.Debug($"Item {item.Id} needs work on part {part.Id}.");
            return true;            
        }
    
        public bool DoWork(Item item) {
            if (!NeedsMoreWork(item, out Part part))
                return false;
            log.Debug($"Starting work on part {part.Id}.");
            // Do work on part.
            log.Debug($"Work completed on part {part.Id}.");
            return true;
        }
    }

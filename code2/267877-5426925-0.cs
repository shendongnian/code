    public class Status {
        public string A {
            get; set;
        }
    
        public string B {
            get; set;
        }
    
        public string C {
            get; set;
        }
    }
    
    public static class StatusManager {
        private static Dictionary<string, Status> statusMap = new Dictionary<string,Status>();
    
        public static Status GetStatus(string name) {
            Status status;
            if (!statusMap.TryGetValue(name, out status))
                statusMap[name] = status = new Status();
            return status;
        }
    
        public static void SetStatus(string name, Status status) {
            statusMap[name] = status;
        }
    
        public static void UpdateVarx(string name, string varx) {
            GetStatus(name).A = varx;
        }
        // ...
    }

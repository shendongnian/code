    // Use of constructor to initialize your class (AtMap.cs)
    public class AtMap {
        public AtMap(string srSys, string desSys, int srFl, int desFl) {
            if (!string.IsNullOrEmpty(a.srSys)) {
                this.srSys = a.srSys;
            }
            if (!string.IsNullOrEmpty(a.desSys)) {
                this.desSys = a.desSys;
            }
            // Int cannot be null
            if (a.srFl != 0) {
                this.srFl = a.srFl;
            }
            // Int cannot be null
            if (a.desFl != 0) {
                this.desFl = a.desFl;
            }
        }
    }

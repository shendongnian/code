    // Use of constructor to initialize your class (AtMap.cs)
    public class AtMap {
        public string srSys, desSys;
        public int? srFl, desFl;
        public AtMap(string srSys, string desSys, int? srFl, int? desFl) {
            if (!string.IsNullOrEmpty(a.srSys)) {
                this.srSys = a.srSys;
            }
            if (!string.IsNullOrEmpty(a.desSys)) {
                this.desSys = a.desSys;
            }
            if (a.srFl != null) {
                this.srFl = a.srFl;
            }
            if (a.desFl != null) {
                this.desFl = a.desFl;
            }
        }
    }

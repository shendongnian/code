    public class FloorManager {
        private List<FloorInfo> floors;
        public FloorManager() {
            floors = new List<FloorInfo>();
        }
        public IEnumerable<FloorInfo> Floors => floors;
        public FloorInfo FindFloorByName(string name) {
            FloorInfo fInfo = floors.Find(floor => floor.Name == name);
            return fInfo;
        }
        public  void Add(FloorInfo floor) {
            floors.Add(floor);
        }
    }
    public class FloorInfo {
        public String Name { get; set; }
    }

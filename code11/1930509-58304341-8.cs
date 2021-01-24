    public class FloorManager {
        private IFloorCollection floors;
        public FloorManager(IFloorCollection floors) {
            this.floors = floors;
        }
        public IEnumerable<FloorInfo> Floors => floors.All;
        public FloorInfo FindFloorByName(string name) {
            FloorInfo fInfo = floors.Find(floor => floor.Name == name);
            return fInfo;
        }
        public void Add(FloorInfo floor) {
            floors.Add(floor);
        }
    }
    public interface IFloorCollection {
        IEnumerable<FloorInfo> All { get; }
        void Add(FloorInfo floor);
        FloorInfo Find(Func<FloorInfo, bool> p);
    }
    public class FloorInfo {
        public String Name { get; set; }
    }

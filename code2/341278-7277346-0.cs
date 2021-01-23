    internal static class DataLayer {
        public static bool Update(int id, string label) {
            // Update your data tier
            return success; // bool whether it succeeded or not
        }
    }
    internal class BusinessObject {
        public int ID {
            get;
            private set;
        } 
        public string Label {
            get;
            set;
        } 
        public bool Save() {
            return DataLayer.Update(this.ID, this.Label); // return data layer success
        }
    }

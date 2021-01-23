    public class LocationNode {
        public LocationNode Parent { get; set; }
        public List<LocationNode> Children = new List<LocationNode>();
        
        public int ID { get; set; }
        public int LocationID { get; set; }
        public string Name { get; set; }
        
        public void Add(LocationNode child) {
            child.Parent = this;
            this.Children.Add(child);
        }
        
        public LocationNode Get(int id) {
            LocationNode result;
            foreach (LocationNode child in this.Children) {
                if (child.ID == id) {
                    return child;
                }
                result = child.Get(id);
                if (result != null) {
                    return result;
                }
            }
            return null;
        }
    }

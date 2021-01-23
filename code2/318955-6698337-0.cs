    class YourImplementedComparer: IEqualityComparer<Item> {
    
        public bool Equals(Item x, Item y) {
            return x.X== y.X &&
                x.Y == y.Y &&
                x.Y == y.Y
        }
    
        public int GetHashCode(Item obj) {
            return obj.X.GetHashCode() ^
                obj.Y.GetHashCode() ^
                obj.ID.GetHashCode() ;
        }
    }

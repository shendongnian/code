     public class ProductTypeEqualityComparer : IEqualityComparer
    {
        public bool Equals(Search x, Search y) {
     // I'm assuming here that the ID is unique to each type, but if it is 
            return x.Id == y.Id; 
        }
        public int GetHashCode(Search obj) {
            return obj.Id.GetHashCode();
        }
    }

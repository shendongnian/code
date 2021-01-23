     public class ProductTypeEqualityComparer : IEqualityComparer<Type>
    {
        public bool Equals(Type x, Type y) {
     // I'm assuming here that the ID is unique to each type, but if it is 
            return x.Id == y.Id; 
        }
        public int GetHashCode(Type obj) {
            return obj.Id.GetHashCode();
        }
    }

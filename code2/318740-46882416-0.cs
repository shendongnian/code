    public class Class_reglementComparer : IEqualityComparer<Class_reglement>
    {
        public bool Equals(Class_reglement x, Class_reglement y)
        {
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Numf == y.Numf;
        }
        public int GetHashCode(Class_reglement product)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(product, null)) return 0;
            //Get hash code for the Numf field if it is not null. 
            int hashNumf = product.hashNumf == null ? 0 : product.hashNumf.GetHashCode();
            return hashNumf;
        }
    }

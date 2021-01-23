     public class CustomEqualityComparer : IEqualityComparer<vClientMedication>
    {
        #region IEqualityComparer Members
 
        public bool Equals(vClientMedication x, vClientMedication y)
        {
            if ((x.BrandName == y.BrandName))
                return true;
            else
                return false;
        }}

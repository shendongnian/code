    public class ObJectArrayEqualityComparer : IEqualityComparer<object[]>
    { 
        public bool Equals(object[] x, object[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                var tempX = x[i];
                var tempY = y[i];
                if ((tempX==null || tempX ==DBNull.Value) 
                    && (tempY == null || tempY == DBNull.Value))
                {
                    return true;
                }
    
                if (!tempX.Equals(tempY) 
                    && !System.Collections.StructuralComparisons.StructuralEqualityComparer.Equals(tempX, tempY))
                {
                    return false;
                }
            }
            return true;
        }
    
        public int GetHashCode(object[] obj)
        {
            if (obj.Length == 1)
            {
                return obj[0].GetHashCode();
            }
    
            int result = 0;
                       
            for (int i = 0; i < obj.Length; i++)
            {
                result = result + (obj[i].GetHashCode() * (65 + i));
            }
    
            return result;
        }
    }

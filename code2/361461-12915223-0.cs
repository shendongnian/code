    public class XElementComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y) 
        {
            return (x.FirstAttribute.Value.Equals(y.FirstAttribute.Value) 
                    && x.LastAttribute.Value.Equals(y.LastAttribute.Value)); 
        } 
        
        public int GetHashCode(XElement x) 
        { 
            return x.Value.GetHashCode(); 
        }
    }

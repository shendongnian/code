    class XElementEqualityComparer : IEqualityComparer<XElement>
        {
            #region IEqualityComparer<XElement> Members
    
            public bool Equals(XElement x, XElement y)
            {
                if (x == null ^ y == null)
                    return false;
    
                if (x == null && y == null)
                    return true;
    
                return x.Value == y.Value;
            }
    
            public int GetHashCode(XElement obj)
            {
                if (obj == null)
                    return 0;
    
                return obj.Value.GetHashCode();
            }
    
            #endregion
        }

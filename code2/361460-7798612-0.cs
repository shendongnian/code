    public class XElementComparer : IEqualityComparer<XElement>
            {
                public bool Equals(XElement x, XElement y)
                {
                    string unitNameX = x.Element("unitName ").Value;
                    string unitNameY = y.Element("unitName ").Value;
                    return unitNameX == unitName Y;
                }
    
                public int GetHashCode(XElement x)
                {
                    string val = x.Element("unitName ").Value;
                    return val.GetHashCode();
                }
            }

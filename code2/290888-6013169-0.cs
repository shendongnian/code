    public class MyFileComparer2 : IEqualityComparer<MyFile>
    {
    
        public bool Equals(MyFile s, MyFile d)
        {
            return
                s.compareName.Equals(d.compareName) &&
                s.size == d.size &&
                s.deepness == d.deepness &&
                //s.dateModified.Date <= d.dateModified.Date &&
                s.dateModified.Ticks >= d.dateModified.Ticks
                ;  
    
        }
    
        public int GetHashCode(MyFile a)
        {
            int rt = (((a.compareName.GetHashCode() * 251)
                    + a.size.GetHashCode() * 251)
                    + a.deepness.GetHashCode() * 251)
                    //+ a.dateModified.Ticks.GetHashCode();                       
                    ;
    
            return rt;
    
        }
    }

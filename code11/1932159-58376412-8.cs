    public class ElementComparer : IEqualityComparer<Element>
    {
        public bool Equals(Element a, Element b) => typeof(Element).GetProperties()
                                               .Where(p => p.Name != "price")
                                               .All(p => p.GetValue(a).Equals(p.GetValue(b)));
        public int GetHashCode(Element obj) => obj.no.GetHashCode();
    }

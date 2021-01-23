    public class PremiseObject
    {
        public static Dictionary<string, PremiseObject> PremiseObjects { get; private set; }
        static PremiseObject()
        {
            PremiseObjects = new Dictionary<string, PremiseObject>();
        }
    }
    public class DerivedPremiseObject : PremiseObject
    {
        private DerivedPremiseObject()
        {
        }
        public static DerivedPremiseObject GetDerivedPremiseObject(string location)
        {
            DerivedPremiseObject po = null;
            if (!PremiseObject.PremiseObjects.TryGetValue(location, out po))
            {
                po = new DerivedPremiseObject();
                PremiseObject.PremiseObjects.Add(location, po);
             }
            return po;
        }
    }

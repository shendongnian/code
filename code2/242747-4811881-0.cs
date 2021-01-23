    public class DerivedPremiseObject : PremiseObject
    {
        private DerivedPremiseObject()
        {
        }
        public static DerivedPremiseObject GetDerivedPremiseObject(Dictionary<string, PremiseObject> premiseObjects, string location)
        {
            DerivedPremiseObject po = null;
            if (!premiseObjects.TryGetValue(location, out po))
            {
                po = new DerivedPremiseObject();
                premiseObjects.Add(location, po);
             }
            return po;
        }
    }

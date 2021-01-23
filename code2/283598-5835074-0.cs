    public class CacheableCollectionConvention : IHasManyConvention, IHasManyConventionAcceptance {
        public void Apply (IOneToManyCollectionInstance instance) {
            instance.Cache.NonStrictReadWrite ();
        }
    
        public void Accept (IAcceptanceCriteria<IOneToManyCollectionInspector> criteria) {
            //whatever
        }
    }

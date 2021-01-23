    public class CacheableCollectionConvention : IHasManyConvention, IHasManyConventionAcceptance {
        public void Apply (IOneToManyCollectionInstance instance) {
            instance.Cache.ReadWrite ();
        }
    
        public void Accept (IAcceptanceCriteria<IOneToManyCollectionInspector> criteria) {
            //whatever
        }
    }

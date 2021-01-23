    public class Poolable
    {
        public Action Free { get; set; }
        public Action OnFree { get { return GetOnFree(); } }
    
        protected virtual Action GetOnFree() { throw new NotImplementedException(); }
    }
    
    public static class PoolHelper<T> where T : Poolable
    {
        public static Action OnFree { get; set; }
    }
    
    public class Light : Poolable
    {
        static Light()
        {
            PoolHelper<Light>.OnFree = () => 
            {
                // Define 'OnFree' for the Light type here...
                // and do so for all other other sub-classes of Poolable
            };
        }
    
        protected override Action GetOnFree()
        {
            return PoolHelper<Light>.OnFree;
        }
    }

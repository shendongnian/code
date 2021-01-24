    public class A : MonoBehaviour
    {
        public static List<A> AvailableAs = new List<A>();
    
        private void Awake()
        {
            if(!AvailableAs.Contains(this)) AvailableAs.Add(this);
        }
    
        private void OnDestroy()
        {
            if(AvailableAs.Contains(this)) AvailableAs.Remove(this);
        }
    
        public void SomePublicMethod()
        {
            // magic
        }
    }

    public abstract class SomeBase : MonoBehaviour
    {
        public abstract Type GetT1 { get; }
        public abstract Type GetT2 { get; }
    }
    
    public class SomeClass<T1, T2> : SomeBase
    {
        public override Type GetT1
        {
            get { return typeof(T1); }
        }
    
        public override Type GetT2
        {
            get { return typeof(T2); }
        }
    }

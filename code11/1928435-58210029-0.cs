    public interface IDoSomething
    {
        void Dosomething();
    }
    public class something1 : MonoBehaviour, IDoSomething
    {
        public void Dosomething() { }
    }
    public class something2 : MonoBehaviour, IDoSomething
    {
        public void Dosomething() { }
    }

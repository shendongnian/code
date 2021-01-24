    public class B : MonoBehaviour
    {
        public void DoIt()
        {
            foreach(var a in A.AvailableAs)
            {
                a.SomePublicMethod();
            }
        }
    }

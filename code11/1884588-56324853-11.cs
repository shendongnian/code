    public class B : MonoBehaviour
    {
        // run the method on all currently registered A instances
        public void DoIt()
        {
            foreach(var a in A.AvailableAs)
            {
                a.SomePublicMethod();
            }
        }
    }

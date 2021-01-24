    public class B : MonoBehaviour
    {
        // drag in via the Inspector
        public A AReference;
        private void Start()
        {
            // or get it on runtime e.g.
            AReference = GameObject.Find("ObjectWithA").GetComponent<A>();
            // or if there is only one e.g.
            AReference = FindObjectOfType<A>();
            Debug.Log(AReference.GetObjectPosition());
        }
    }

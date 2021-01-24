    public class Registration : MonoBehaviour
    {
        // Reference this via the Unity Inspector by drag&drop the according GameObject here
        [SerializeField] private Homepage homepage;
    
        private void Awake()
        {
            // You could still have a fallback here
            if(! homepage) homepage = FindObjectOfType<Homepage>();
        }
        ...
    }

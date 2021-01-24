    public class DestructableObject : MonoBehaviour
    {
        // Adjust this through the inspector
        public DestructableType Type;
    
        private void OnDestroy ()
        {
            FindObjectOfType<scoreCount>().ObjectsDestroyed(Type);
        }
    }

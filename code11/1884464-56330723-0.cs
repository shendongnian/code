    public class Scale : MonoBehaviour {
    
        public float scale = 1f; // 1 by default
    
        public void Update()
        {
            GetComponent<Canvas>().scaleFactor = scale;
        }
    }

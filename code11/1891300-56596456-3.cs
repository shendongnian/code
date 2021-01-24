        public class bluescript : MonoBehaviour
        {
            public bool bluetopurple = false;
    
            // Use this for initialization
            private void Start () 
            {
                Renderer render = GetComponent<Renderer>();
                render.material.color = Color.blue;
            } 
    
            // Catch the mousedown
            private void OnMouseDown()
            {
                bluetopurple = true;
            }
        }
        

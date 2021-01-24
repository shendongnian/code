    public class MoveBall : MonoBehaviour
    {
        public static Vector2 mousePos = new Vector2();
    
        // On mouse down enable DontDestroyOnLoad
        private void OnMouseDown()
        {
            gameObject.SetDontDestroyOnLoad(true);
        }
    
        // Do your dragging part here
        private void OnMouseDrag()
        {
            // NOTE: Your script didn't work for me
            // in ScreenToWorldPoint you have to pass in a Vector3
            // where the Z value equals the distance to the 
            // camera/display plane
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                transform.position.z)));
            transform.position = mousePos;
        }
    
        // On mouse up disable DontDestroyOnLoad
        private void OnMouseUp()
        {
            gameObject.SetDontDestroyOnLoad(false);
        }
    }
    

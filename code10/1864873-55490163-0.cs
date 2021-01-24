    public class ItemClickable : MonoBehaviour
    {
    
        public Transform player;        // player-transform reference (depends if you have a singleton or not)
        public float range;             // radius (maybe you have a range or radius already set in your player instance)
    
        void Start()
        {
            // Setup for your references        
        }
    
       
        private void OnMouseDown()
        {   
            // Checks if the item is in the range of the player
            if ((player.position-gameObject.transform.position).magnitude < range) // Vector3.Distance() is also possible
            {
                Destroy(gameObject); // or do whatever you want in here
            }
        }
    }

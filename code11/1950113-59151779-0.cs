        public class PlayerMovement : MonoBehaviour
        {
            bool moveLeft = false;    
    
  
            void Update()
            {
        
                if (Input.GetMouseButton(0))
                {
                   moveLeft = true;
                }
    
                if(moveLeft)
                {
                   //Your Movement Code
                }        
    
            }  
        }

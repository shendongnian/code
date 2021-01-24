          public class SpriteFlipper : MonoBehaviour
    {
       // variable to hold a reference to our SpriteRenderer component
       private SpriteRenderer mySpriteRenderer;
     
       // This function is called just one time by Unity the moment the component loads
       private void Awake()
       {
            // get a reference to the SpriteRenderer component on this gameObject
            mySpriteRenderer = GetComponent<SpriteRenderer>();
       }
     
       // This function is called by Unity every frame the component is enabled
       private void Update()
       {      
            // if the A key was pressed this frame
            if(Input.GetKeyDown(KeyCode.A))
            {
                // if the variable isn't empty (we have a reference to our SpriteRenderer
                if(mySpriteRenderer != null)
                {
                     // flip the sprite
                     mySpriteRenderer.flipX = true;
                }
            }
        }
    }

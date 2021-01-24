    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "cubo")
        {
            other.gameObject.setActive = false; // better than destroying in most cases
            // get all other draggable objects
            arrastrar[] remainingObjects = Object.FindObjectsOfType<arrastrar>();
            if (remainingObjects.Length == 0)
            {
                // there are no more active gameobjects with enabled arrastrar component
                // handle win condition here.
            }  
        }
        // ...
 

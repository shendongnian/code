    /* The following script is called when a Rigidbody detects a collider that is
     * is set to be a trigger. It then passes that collider as a parameter, to this 
     * function.
     */
    void OnTriggerEnter (Collider other) 
    { 
        // So here we have the other / coin collider
        
        // If the gameObject that the collider belongs to has a tag of coin
        if (other.gameObject.tag == "Coin") 
        {
            // Set the gameObject that the collider belongs to as SetActive(false)
            other.gameObject.SetActive(false); 
        }
    }

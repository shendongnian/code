       /* The following script is called when a Rigidbody detects a collider that is
          is set to be a trigger. It then passes that collider as a parameter, to this 
          function.
       */
       void OnTriggerEnter (Collider other) { // So here we have the other / coin collider
        
            if (other.gameObject.tag == "Coin") // If the gameObject that the collider belongs to has a tag of coin
            {
                other.gameObject.SetActive(false); // Set the gameObject that the collider belongs to as SetActive(false)
            }
        }

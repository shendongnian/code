    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Hole"))
        {
            holePosition = other.transform.position;
            holeColliding = true;
            Debug.Log("true");
        }
        else if(other.CompareTag("Tree"))
        {
            treeColliding = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Hole"))
        {
            holeColliding = fase;
        }
        else if(other.CompareTag("Tree"))
        {
            treeColliding = false;
        }
    }

    public Transform respawnPoint;
    
    void OnTriggerEnter(Collider other)
    {    
        if (other.CompareTag("Basketball"))
            other.transform.position = respawnPoint.position;
    }

    public Vector3 respawnPoint = Vector3.zero;
    
    void OnTriggerEnter(Collider other)
    {    
        if (other.CompareTag("Basketball"))
            other.transform.position = respawnPoint;
    }

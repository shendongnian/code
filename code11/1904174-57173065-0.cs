    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube") && other.rigidbody == null)
        {
            other.gameObject.AddComponent<Rigidbody>();
        }
    }

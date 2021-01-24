    private bool coinCollected = false
    private void OnTriggerEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            coinCollected = true;
        }
    }

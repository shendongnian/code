    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Block")
        {
            movement.enabled = false;
        }   FindObjectOfType<GameManager>().EndGame();// <--- It is outside the if
    }

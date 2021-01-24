    voi OnTriggerEnter(Collider other)
    {
        CanMove = true;
        other.GetComponent<CollisionHandler>().CanMove = false;
    }

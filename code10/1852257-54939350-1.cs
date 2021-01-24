    voi OnCollisionEnter(Collision other)
    {
        CanMove = true;
        other.GetComponent<CollisionHandler>().CanMove = false;
    }

    voi OnTriggerEnter(Colider other)
    {
        CanMove = true;
        other.GetComponent<CollisionHandler>().CanMove = false;
    }

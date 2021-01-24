    public static GameObject lastReset;
    void OnTriggerEnter(Collider other)
    {
        if(lastReset != gameObject) return;
        // You way to define if can move
        CanMove = ...;
    }

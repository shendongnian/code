    Vector3 explosionPos = transform.position;
    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
    foreach (Collider hit in colliders)
    {
        Rigidbody rb = hit.GetComponent<Rigidbody>();
        if (rb != null)
            //                                                |
            //                                                v
            rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
    }
    

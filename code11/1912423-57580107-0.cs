        if (transform.position.y > 2.7f)
        {
            r.mass = 50000f;
            Physics.gravity = new Vector3(0, -100f, 0);
        }
        if (grounded)
        {
            r.mass = 10f;
            Physics.gravity = new Vector3(0, -10f, 0);
        }

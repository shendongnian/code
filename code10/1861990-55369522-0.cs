    float yvel = 1f, xvel;
    float t;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, yvel);
        t += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.D))
        {
            t = 0;
            StartCoroutine(Move());
        }
    }
    private IEnumerator Move()
    {
        while (t < 2) // at time t, yvel will be zero and xvel will be 1
        {
            yvel = 1 - .5f * t; // decrease velocity in old direction
            xvel = .5f * t; // increase velocity in new direction
            yield return null;
        }
    }

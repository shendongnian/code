    void Start()
    {
        //Invoke("Kill", life);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if (isGrounded)
        {
          StartCoroutine( Kill());
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    //
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    //Explosion code
    IEnumerator Kill()
    {
        Vector3 explosionCenterPosition = transform.position;
        rb.AddExplosionForce(explosionForce, explosionCenterPosition, explosionRadius);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

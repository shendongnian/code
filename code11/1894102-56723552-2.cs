    // Update is called once per frame
    void Update()
    {
        float tHorizontal = Input.GetAxis("Horizontal");
        //float tVertical = Input.Get
        if (tHorizontal != 0.0f) {
            mDTS.movement += (Vector2)transform.right * speed * tHorizontal * Time.deltaTime;
        } else {
            mDTS.movement = Vector2.Zero;
        }
    }

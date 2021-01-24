    public float energyBarDrainRate = 1f;
    private bool isSprinting = false;
    void Update() { 
        isSprinting = Input.GetAxis("Sprint") > 0f;
        Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mv = mi.normalized * speed;
    }

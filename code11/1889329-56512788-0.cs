        public float waitTime = 0f;
    public void Update()
    {
        waitTime = waitTime + Time.deltaTime;
        if (Input.GetKeyDown("e"))
        {
            BoxCollider.enabled = false;
            waitTime = 0;
        }
        if (waitTime >= 2)
        {
            BoxCollider.enabled = true;
        }

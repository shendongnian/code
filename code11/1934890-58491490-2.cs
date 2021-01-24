    public float speed =10.0f;
    void Update()
    {
    Vector3 a = transform.position
    	if(Input.GetKeyDown("W"))
    	{
    		a.position.y += speed *Time.deltaTime
    	}
    	if(Input.GetKeyDown("S"))
    	{
    		a.position.y -= speed *Time.deltaTime
    	}
    transform.position =a;
    }

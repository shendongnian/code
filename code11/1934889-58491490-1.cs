    public float speed =10.0f;
    void Update()
    {
    	if(Input.GetKeyDown("W"))
    	{
    		tranform.position.y += speed *Time.deltaTime
    	}
    	if(Input.GetKeyDown("S"))
    	{
    		tranform.position.y -= speed *Time.deltaTime
    	}
    }

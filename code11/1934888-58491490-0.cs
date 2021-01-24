    public float speed =10.0f;
    void Update()
    {
    	if(Input.GetKeyDown("W"))
    	{
    		tranform.position += speed *Time.deltaTime
    	}
    	if(Input.GetKeyDown("S"))
    	{
    		tranform.position -= speed *Time.deltaTime
    	}
    }

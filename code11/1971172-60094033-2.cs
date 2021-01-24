    bool collides = false;
    
	void FixedUpdate()
	{
        print(collides);
        collides = false;
	}
    void OnCollisionStay(Collision collision)
    {
        collides = true;
	}
	

    private float _delay = 2f;
    private float _startTime;
    
    private void Start()
    {
    	_startTime = Time.time;
    }	
    
    void OnCollisionEnter (Collision col)
    {
    	if(Time.time - _startTime < _delay)
    	{
    		//Exit if the time passed is less than the _delay
    		return;
    	}
    	//Else run check against player
    	if (col.gameObject.name == "Player")
    	{
    		Debug.Log("collision detected");
    
    		Destroy(gameObject);
    
    	}
    }

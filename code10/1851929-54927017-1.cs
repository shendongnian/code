    public GameObject Target;
    public GameObject GreenSphere;
	
	void Start () {
		
	}
		
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {       
        //Since you used Target as a public variable
        if(collision.gameObject == Target)
        {
            GreenSphere.transform.parent = Target.transform;
        }
    }

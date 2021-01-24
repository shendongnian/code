    void Start()
    {       
        oldPosition.y = Cylinder.transform.position.y;
    }
    void Update()
    {
        if(oldPosition.y > Cylinder.transform.position.y)
        {
            oldPosition.y = Cylinder.transform.position.y;
        }
        if(oldPosition.y < Cylinder.transform.position.y)
        {             
            oldPosition.y = Cylinder.transform.position.y;
        }
    }

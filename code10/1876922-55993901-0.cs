    public bool touchedCollision; //you already had this, but weren't using it
    // Update is called once per frame
    void Update()
    {
        if (touchedCollision)
        {
            Debug.Log("IN COLL");
        }
        if(!touchedCollision) //can be changed to just `else`
        {
            Debug.Log("NOT IN COLL");
        }
    }

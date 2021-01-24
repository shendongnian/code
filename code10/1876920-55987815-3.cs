    public DisableInput disableInput;
    
    // Update is called once per frame
    void Update()
    {
        if (disableInput.touchedCollision)
        {
            Debug.Log("IN COLL");
        }
        else //you don`t need to specify the condition again, you can do it with and else
        {
            Debug.Log("NOT IN COLL");
        }
    }

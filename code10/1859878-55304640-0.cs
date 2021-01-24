    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;
    
    	
    // Update is called once per frame
    void Update () {
    
        if (CheckGrab())
        {
            Debug.Log("GRAB ACTION");
        }
    }
    
    private bool CheckGrab()
    {
        return grabAction.GetState(handType);
    }

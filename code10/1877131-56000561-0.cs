    public void Start () 
    {
        if(receiveScript = FindObjectOfType<ReceiveScript>())
        {
            Debug.Log("Found Script!");
            return;
        }
        Debug.Log("Didn't find script!");
    }

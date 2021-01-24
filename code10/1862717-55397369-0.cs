    public PlayerHealth P_Health;
    
    void Start()
    {
        P_Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    //Reference this action as Onclickevent through the Inspector inside your button
    void OnMyClick()
    {
        P_Health.GainHealth(50);
    }

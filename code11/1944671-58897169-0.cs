    public Player soldier
    {
        get
        {
            return ReInput.players.GetPlayer(0);
        }
    }
    [SerializeField] public Player engineer
    {
        get
        {
            return ReInput.players.GetPlayer(1);
        }
    }
    [SerializeField] public Player medic
    {
        get
        {
            return ReInput.players.GetPlayer(2);
        }
    }
    [SerializeField] public Player scout
    {
        get
        {
            return ReInput.players.GetPlayer(3);
        }
    }

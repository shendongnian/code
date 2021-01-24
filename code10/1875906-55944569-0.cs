    public GameObject[] guards;
    void Start ()
    {
        guards = GameObject.FindGameObjectsWithTag("Guard");
        print(guards.Length);
    }

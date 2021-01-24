    // Assign this inside the editor
    public GameObject Race;
    
    void Start()
    {
        Do();
    }
    
    private void Do()
    {
        // Instantiating 1000 gameobjects is nothing imo, if yes split it then, with a coroutine
        for(int i=0;i<1000;i++)
        {
            GameObject RaceGO = Instantaite(Race);
            RaceGO.transform.SetParent(Content);
        }
    }

    GameObject raceGameObject;
    // Start "Message" can be a coroutine
    IEnumerator Start()
    {
        // Load the resource "Race" asynchronously
        var request = Resources.LoadAsync<GameObject>("Race");
        while(!request.IsDone) {
            yield return request;
        }
        raceGameObject = request.asset;
        Do();
    }
    
    private void Do()
    {
        // Instantiating 1000 gameobjects is nothing imo, if yes split it then, with a coroutine
        for(int i=0;i<1000;i++)
        {
            GameObject RaceGO = Instantaite(raceGameObject);
            RaceGO.transform.SetParent(Content);
        }
    }

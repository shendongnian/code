    
    private void Awake()
    {
        UpdateDoors();
    }
    public void UpdateDoors()
    {
        var doors = GameObject.FindGameObjectsWithTag("Door");
        Doors = new HoriDoorManager[doors.Length].ToList();
        for (int i = 0; i < doors.Length; i++)
        {
            Doors[i] = doors[i].GetComponent<HoriDoorManager>();
        }
    }

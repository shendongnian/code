    public GameObject YellowPrefab;
    public int howManyYellow;
    private List<Vector3> locations;
    void Start()
    locations = new List<Vector3>();
    { 
        GameObject tmpYellow;
        for (int i = 0; i < howManyYellow; i++)
        {
            bool hasItem = false;
             Vector3 tempLocation;
            do{
                tempLocation = new Vector3(Random.Range(-50, 50), Random.Range(-40, -17), 0);
                foreach (Vector3 item in locations)
                {
                    if(tempLocation != item){
                        locations.Add(tempLocation);
                        hasItem = false;
                    }
                    else
                    {
                        hasItem = true;
                    }
                }
            } while(hasItem);
            
            tmpYellow = Instantiate(YellowPrefab, tempLocation, Quaternion.identity);
        }
    }
 

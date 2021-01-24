    public Item[] stages;
    
    public void ObjectActivation(string stageActivation) //I'd use an int tho, see below
    {
        //stageOne
        if (stageActivation == "StageOne") {
            stages[0].SetActive(true);
            stages[1].SetActive(false);
        }
        // ...
    }

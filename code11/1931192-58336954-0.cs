    List<GameObject> GameObjectList = new List<GameObject>();
    GameObjectDictionary ParentDictionary = new GameObjectDictionary();
    
    public void GetChildren(){
    
        foreach(GameObject parent in GameObjectList){
            foreach(Transform child in parent.transform){
                ParentDictionary.Add(parent, child.gameObject)
            }
        }
    }

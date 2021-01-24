    public List<GameObject> prefabsWithClassOnThem;
    
    public GameObject CheckTheID(string ID)
    {
        foreach (GameObject go in prefabsWithClassOnThem)
        {
            if(go.GetComponent<ItemClass>().getID() == ID){
                return go;
            }
        }
        return null;
    }

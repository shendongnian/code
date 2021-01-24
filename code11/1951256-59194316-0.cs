    public GameObject prefabInstance;
    List<Object> prefabInstanceClones = new List<Object>();
    void Update()
    {
        Debug.Log(prefabInstanceClones.Count);
        if (Input.GetKeyDown("c"))
        {
            prefabInstanceClones.Add(Instantiate(prefabInstance, transform.position, Quaternion.identity));
        }
        if (Input.GetKeyDown("d"))
        {
            var last = prefabInstanceClones.LastOrDefault();
            prefabInstanceClones.Remove(last);
            Destroy(last);
        }
    }

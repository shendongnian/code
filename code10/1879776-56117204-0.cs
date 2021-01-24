    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    GameObject myPrefabInstance;
    
        // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
    	// Instantiate at position (0, 0, 0) and zero rotation.
    	myPrefabInstance = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }
    
    private void OnDestroy()
    {
        myPrefabInstance.GetComponent<MeshRenderer>().enabled = false;
        myPrefabInstance.GetComponent<BoxCollider2D>().enabled = false;
    }

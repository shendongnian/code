    public GameObject    Elements_1;
    public GameObject    Content_image_1;
    public GameObject    Content_tittle_1;
    public GameObject    Content_Options_1;
    //...
    
    //instances yours objects
    
    //...
    public void makeChildren_1(){
     Elements_1.transform.parent = GameObject.FindGameObjectsWithTag("Content_image_1");
    Elements_1.transform.parent = GameObject.FindGameObjectsWithTag("Content_tittle_1");
    Elements_1.transform.parent = GameObject.FindGameObjectsWithTag("Content_Options_1");
    }

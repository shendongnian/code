    //Declare a variable that points to a specific object and a target obj variable
    public GameObject obj1;
    public GameObject obj2;
    GameObject targetObj;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            OnChangedTarget(obj1);
        if (Input.GetKeyUp(KeyCode.Alpha2))
            OnChangedTarget(obj2);
        UpdateObjPos(Camera.main.gameObject);
    }
    
    //Keep distance from target obj
    void UpdateObjPos(GameObject followObj, float width = 10f, float height = 10f)
    {
        if (targetObj == null)
            return;
        followObj.transform.LookAt(targetObj.transform);
        float posX = targetObj.transform.position.x + width;
        float posY = targetObj.transform.position.y + width;
        float posZ = targetObj.transform.position.z + height;
        followObj.transform.position = new Vector3(posX, posY, posZ);
    }
    //Declare function to select target obj
    void OnChangedTarget(GameObject obj)
    {
        Debug.Log("Target Changed : " + obj.name);
        targetObj = obj;
    }
   

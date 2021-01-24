    // If possible it would be better to assign this object in the inspect rather then 
    // using a GameObject.Find method, Also this is error prone due to the timing of 
    // the call, for example if this is in a start this Object may not exist yet.
    // Another solution would to be create an event and when you load the skin
    // Have that event fire off that its been loaded and everything that needs
    // to listen to it will get the change.
    lesnek = GameObject.FindGameObjectsWithTag("LeWorm");
    
    //  GetString has an alternative method where you can pass a default value
    //  I would recommend using this method instead.
    objName = PlayerPrefs.GetString("meshName");    // POINT A
    
    // Honestly this check seems a tad bit redundant since you already
    // attempted to load this preference.
    // POINT B
    if (PlayerPrefs.HasKey("meshName"))  // Since you have said this is empty playerPrefs is empty.
    {
        // At this point it should equal this since you already set it to this in Point A
        if (objName == PlayerPrefs.GetString("meshName"))
        {
            leMesh = Resources.Load<GameObject>(@"Models\" + objName);
        }
        else
        {
            // This case should never get called, because of Point A and your if condition.
            objName = PlayerPrefs.GetString("meshName");
            leMesh = Resources.Load<GameObject>(@"Models\" + objName);
        }
    }
    if (objName != null || objName != "")  // This completely nullifies all the work in Point B
    {
        objName = "Sphere";
        leMesh = Resources.Load<GameObject>(@"Models\" + objName);
    }
    foreach (GameObject change in lesnek)
    {
        if (objName != null || objName != "")
        {
            if (change.GetComponent<MeshFilter>() == null)
            {
                change.AddComponent<MeshFilter>();
                change.GetComponent<MeshFilter>().mesh = leMesh.GetComponent<MeshFilter>().sharedMesh;
                PlayerPrefs.SetString("meshName", objName);
                PlayerPrefs.Save();
            }
            else
            {
                change.GetComponent<MeshFilter>().mesh = leMesh.GetComponent<MeshFilter>().sharedMesh;
                PlayerPrefs.SetString("meshName", objName);
                PlayerPrefs.Save();
            }
        }
    }

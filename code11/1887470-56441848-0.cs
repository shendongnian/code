    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            // int ran = Random.Range(0, 2);
            Debug.Log("Is obj1 a prefab" + (obj1.gameObject.scene.rootCount == 0));
            Debug.Log("Is spawn1 a prefab" + (spawn1.gameObject.scene.rootCount == 0));
            // --------------- Check the object --------------- //
            Transform yourObject;
            if (obj1.gameObject.scene.rootCount == 0) yourObject = Instantiate(obj1);
            else yourObject = obj1;
            
            // --------------- Check the spawn --------------- //
            Transform spawn;
            if (spawn1.gameObject.scene.rootCount == 0) spawn = Instantiate(spawn1);
            else spawn                                        = spawn1;
            
            yourObject.position = spawn.position;
            Debug.Log("Moved");
        }
    }

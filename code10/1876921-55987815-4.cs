      private DisableInput disableInput;
    
    void Awake(){
      disableInput = FindObjectOfType<DisableInput>(); 
    // you only need to get the 
    //class refence one time, no need for it to be in the update, 
    //it gains a lot of performance
    }
        
        // Update is called once per frame
        void Update()
        {
            if (disableInput.touchedCollision)
            {
                Debug.Log("IN COLL");
            }
            else //you don`t need to specify the condition again, you can do it with and else
            {
                Debug.Log("NOT IN COLL");
            }
        }

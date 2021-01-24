    public GameObject[] arrayofcookie;
    public int destroyedinstances=1; 
    //this int will tell how many instances you want to be destroyed (from the last instantiated to the first)
    
    //for this example the last instance will be deleted
    public void destroyCookie()
    {
        arrayofcookie= GameObject.FindGameObjectsWithTag("Cookie");
        for (int i = 0; i < destroyedinstances; i++)
        {
            Destroy(arrayofcookie[i].gameObject);
        }
    }

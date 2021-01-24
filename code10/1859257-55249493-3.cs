    //For example. Instead of this
    private void Start()
    {
        Invoke("LoadAsyncOperation", 3f);
        StartCoroutine(LoadAsyncOperation());
    }
    //Do this
    private void Update()
    {
       //Note that we only need to check if it is a CurrentVersion, as if that is true, then we definitely have internet access.
       if(CheckNetwork.IsCurrentVersion) {
          Invoke("LoadAsyncOperation", 3f);
          StartCoroutine(LoadAsyncOperation());
       }
    }

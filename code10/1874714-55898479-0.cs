        public Vector3 MyGameObjectPosition;
    public Quaternion MyGameObjectRotation;
    //drag prefab here in editor
    public Transform InstantiateMe;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        MyGameObjectPosition = GameObject.Find("L96_Sniper_Rifle").transform.position;
        MyGameObjectRotation = GameObject.Find("L96_Sniper_Rifle").transform.rotation;
        if (Input.GetMouseButtonDown(0))
        {
            //you don't have to instantiate at the transform's positio nand rotation, swap these for what suits your needs
            var go = Instantiate(InstantiateMe, MyGameObjectPosition, transform.rotation);
        }
    }

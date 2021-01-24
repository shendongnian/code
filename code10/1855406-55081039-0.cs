    public GameObject[] menuObjects;
    private bool _menuState = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Change the value of _menuState
            _menuState = !_menuState;
            // Loop through the menu objects
            foreach(GameObject obj in menuObjects)
            {
                // Enable/Disable the objects
                obj.SetActive(_menuState);
            }
            // Do other stuff...
        }
    }

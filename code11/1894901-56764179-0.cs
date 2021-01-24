c#
// Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
        SceneManager.LoadScene("Main Menu");
       }
    }
Add this function your code and it should load scene *Main Menu*.

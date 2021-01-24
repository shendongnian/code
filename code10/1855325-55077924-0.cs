    // This is called when the object gains focus
    private void OnEnable()
    {
        // This makes sure the callback is added only once
        EditorApplication.update -= MyUpdate;
        EditorApplication.update += MyUpdate;
    }
    // This is called when the object loses focus or the Inspector is closed
    private void OnDisable ()
    {
        EditorApplication.update -= MyUpdate;
    }

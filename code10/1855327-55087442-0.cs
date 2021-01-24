    void OrbUpdate()
    {
        try
        {
            MyCustom = (MyCustom)serializedObject.targetObject;
        }
        catch (Exception)
        {
            // Catching that bug :(
        }
    }
    private void OnDisable ()
    {
        // And then unsubscribing
        EditorApplication.update -= MyUpdate;
    }

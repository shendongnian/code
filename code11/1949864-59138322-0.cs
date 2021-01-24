    if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) == (int)Permission.Granted)
    {
    	// We have permission, go ahead and use the camera.
    }
    else
    {
    	// We have not got permission, can't use camera
    }

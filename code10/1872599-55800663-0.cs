    if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted) 
    {
        // We have permission.
    } 
    else 
    {
        // Storage permission is not granted. If necessary display rationale & request.
    }

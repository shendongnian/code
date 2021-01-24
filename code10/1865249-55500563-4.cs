    // Set in the inspector
    public float RotationSpeed;
    private void RotateFromMouseWheel()
    {
        // whatever key you want
        // this makes one rotation each click
        // if you want it continous see below
        if(!Input.GetKeyDown(KeyCode.R)) return;
        currentPlaceableObject.transform.Rotate(Vector3.up, RotationSpeed);
    }
    

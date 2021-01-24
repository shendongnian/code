    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += (viewDir + 90);
        }
        Vector3 newValue = new Vector3(0, Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        // get Y rotation of player
        yRotationAngle = player.transform.rotation.eulerAngles.y;
        
        // convert to Quaternion using only the Y rotation
        Quaternion yRotation = Quaternion.Euler(0f, yRotationAngle, 0f);
        // Apply yRotation
        newValue = yRotation * newValue;
        return newValue;
    }    

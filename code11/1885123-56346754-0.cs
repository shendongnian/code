    // Where the "feet" are relative to the object's origin
    public Vector3 cameraKeepOffset = new Vector3(0f,-1f,0f); 
    public Ray perspectiveRay;
    ...
    Vector3 positionToKeep = transform.position + cameraKeepOffset;
    Vector3 cameraPosition = Camera.main.transform.position;
    perspectiveRay = new Ray(cameraPosition, positionToKeep - cameraPosition);

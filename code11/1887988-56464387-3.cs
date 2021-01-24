    public void RotateMe(RotationAxis axis, float angle) {
        // using axis as a Vector3 guaranteed by type safety to be one of:
        // Vector3.right, Vector3.up, or Vector3.forward
        transform.Rotate(axis, angle);
    }
    ...
  
    RotationAxis axis = RotationAxis.x;
    float angle = 45f;
    object1.RotateMe(axis, angle);
    axis = RotationAxis.y;
    angle = 45f;
    object2.RotateMe(axis, angle);
    // object2.RotateMe(Vector3.zero); would produce a compile error. Can't be done accidentally.
   

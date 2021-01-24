    public void RotateMe(RotationAxis axis, float angle) {
        // using axis as a Vector3 guaranteed by type safety to be one of:
        // Vector3.right/left/up/down/forward/back
        transform.Rotate(axis, angle);
        
        // you can also just use RotationAxis._ as you would Vector3._
        transform.Rotate(RotationAxis.forward, angle);
    }
    ...
  
    RotationAxis axis = RotationAxis.right;
    float angle = 45f;
    object1.RotateMe(axis, angle);
    axis = RotationAxis.up;
    angle = 45f;
    object2.RotateMe(axis, angle);
    // object2.RotateMe(Vector3.zero); would produce a compile error. Can't be done accidentally.
   

c-sharp
public float speed = 2;
public float speedUpFactor = 2;
// Get the Rigidbody component attached to this gameobject
// The rigidbody component is necessary for any object to use physics)
// This gameobject and any colliding gameobjects will also need collider components
Rigidbody rb;
// Start() gets called the first frame that this object is active (before Update)
public void Start(){
    // save a reference to the rigidbody on this object
    rb = GetComponent<Rigidbody>();
}
}// Update() gets called every frame, so you can check for input here.
public void Update() {
    
    // Input.GetAxis("...") uses input defined in the "Edit/Project Settings/Input" window in the Unity editor.
    // This will allow you to use the xbox 360 controllers by default, "wasd", and the arrow keys.
    // Input.GetAxis("...") returns a float between -1 and 1
    Vector3 moveForce = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));
    moveForce *= speed;
    // Input.GetKey() returns true while the specified key is held down
    // Input.GetKeyDown() returns true during the frame the key is pressed down
    // Input.GetKeyUp() returns true during the frame the key is released
    if(Input.GetKey(KeyCode.Shift)) 
    {
        moveForce *= speedUpFactor;
    }
    // apply the moveForce to the object
    rb.AddForce(moveForce);
}

public KeyCode leftKey  = KeyCode.A; // Change to KeyCode.LeftArrow in inspector
public KeyCode rightKey = KeyCode.D;
public float   speed = 1.0f;
private Vector2 _moveVelocity;
private RigidBody2D _rigidBody;
private void Start()
{
    _rigidBody = GetComponent<Rigidbody2D>();
}
private void Update()
{
    Vector2 moveInput = Vector2.zero;
    if(Input.GetKey(leftKey))
    {
        moveInput = Vector2.left;
    }
    
    if(Input.GetKey(rightKey))
    {
        moveInput = Vector2.right;
    }
    _moveVelocity = moveInput * speed * Time.deltaTime;
    _rigidBody.velocity = _moveVelocity;
}

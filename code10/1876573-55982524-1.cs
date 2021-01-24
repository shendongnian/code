    private RigidBody2D rigidBody2D;
    private void Awake()
    {
        rigidBody2D = GetComponent<RigidBody2D>();
    }
    public void MoveLeft()
    {
        rigidBody.MovePosition(transform.position + Vector3.right * -5 * Time.deltaTime);
    }
    public void MoveRight()
    {
        rigidBody.MovePosition(transform.position + Vector3.right * 5 * Time.deltaTime);
    }

    // Adjust in the Inspector how often the cog thing has to be turned
    // in order to make the thingToRotate perform a full 360° rotation
    public float factor = 5f;
    
    private float totalAngle = 0f;
    
    [SerializeField] private Rigidbody2D thingToRotate;
    private void OnMouseDrag()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        // this is shorter ;)
        Vector2 direction = (mousePosition - transform.position).normalized;
    
        // get the angle difference you will move
        var angle = Vector2.SignedAngle(transform.right, direction);
    
        // rotate yourselve correctly
        transform.Rotate(Vector3.forward * angle);
    
        // add the rotated amount to the totalangle
        totalAngle += angle;
    
        // for rigidBodies rather use MoveRotation instead of setting values through
        // the Transform component
        thingToRotate.MoveRotation(totalAngle / factor);
    }
    

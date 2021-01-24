public float speed;    
public float jumpHeight; 
Rigidbody2D rb; 
void Start(){
    //Get the rigidbody2d of the gameObject this script is assigned to.
    rb = GetComponent<Rigidbody2D>();
}
void Update() {
    //Determine the direction of the movement based on user input.
    float moveDir = Input.GetAxis("Horizontal");
    //Calculate the velocity of the gameObject.
    rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);
    // Your jump code:
    if (Input.GetKeyDown(KeyCode.Space))
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
Hope this works for you. If you need more help, check unity's official [turtorials](https://learn.unity.com/tutorials).

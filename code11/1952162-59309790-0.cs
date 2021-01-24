private float movement = 0f;
void Update()
{
    if( Input.GetKey("d") )
    {
        movement = sidewaysForce;
    }
    else if ( Input.GetKey("a") )
    {
        movement = -sidewaysForce;
    }
    else
    {
        movement = 0f;
    }
}
void FixedUpdate()
{
    rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime); 
    rb.AddForce(movement * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
}
I've also updated `Time.deltaTime` to `Time.fixedDeltaTime` since you are calling it in `FixedUpdate()`.
Finally, you may want to test with different force modes when adding the sideways force.

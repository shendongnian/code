void OnCollisionStay2D(Collision2D col) 
{
    isJumping = false;
}
And you shouldn't put this method inside your Update method... It should be on class level:
public class RonyWalking
{
    void Update() 
    {
        // ...
    }
    void OnCollisionStay2D(Collision2D col) 
    {
        // ...
    }
}
Don't worry about "Is declared but never used", this may be because you don't have specific code referencing the method, but Unity will raise events that calls it, "automagically" 

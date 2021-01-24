c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;
    public Transform playerTF;
    public float moveForce;
    public float rotateForce;
    private Vector3 movement;
    private string currentRotateKey = "";
    void Update()
    {
        //move in Local space
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement += Vector3.up;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            movement -= Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement -= Vector3.up;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movement += Vector3.up;
        }
        //rotate
        if (Input.GetKeyDown("a") && currentRotateKey == "")
        {
            currentRotateKey = "a";
        }
        if (Input.GetKey("a") && currentRotateKey == "a")
        {
            playerTF.Rotate(transform.forward * rotateForce * Time.deltaTime);
        }
        if (Input.GetKeyUp("a") && currentRotateKey == "a")
        {
            currentRotateKey = "";
        }
        if (Input.GetKeyDown("d") && currentRotateKey == "")
        {
            currentRotateKey = "d";
        }
        if (Input.GetKey("d") && currentRotateKey == "d")
        {
            playerTF.Rotate(transform.forward * -rotateForce * Time.deltaTime);
        }
        if (Input.GetKeyUp("d") && currentRotateKey == "d")
        {
            currentRotateKey = "";
        }
        // Implicit cast from Vector3 to Vector2, takes X and Ys
        ApplyMovement(movement);
    }
    public void ApplyMovement(Vector2 movement)
    {
        playerRB.velocity = player.transform.TransformDirection(movement.x, movement.y, 0) * moveForce * Time.deltaTime;
    }
}
I find it a little cleaner to use the `KeyCode` enums instead of string values, and I like to track a local `Vector3 movement` for the class instead of checking `currentMovementKey`. This lets you press multiple keys at a time, and catch spelling errors at compile time.
Moving where you "apply" your movement into it's own method helps change your behaviour when you want to.
`movement` is handled in local space, using `Vector3.up` instead of `transform.up` to avoid errors while rotating, then when applied to the `playerRB.velocity` we can convert back into world space using `player.transform.TransformDirection(movement.x, movement.y, 0)` (which could also be `transform.TransformDirection(movement.x, movement.y, 0)` if this component was on the same GameObject as the RigidBody2D component).
If you wanted to still have acceleration instead of jumping up and falling back down in speed, but did not want any drift like a real object things get a little trickier, here is one way of how to solve that problem: 
c#
    public void ApplyMovement(Vector3 movement)
    {
        if (movement.sqrMagnitude > Mathf.Epsilon)
        {
            playerRB.drag = 0; // or some other small value
            if (playerRB.velocity.sqrMagnitude > Mathf.Epsilon)
            {
                playerRB.velocity = player.transform.TransformDirection(movement.normalized) * playerRB.velocity.magnitude;
            }
            
            playerRB.AddRelativeForce(movement * moveForce * Time.deltaTime);
        }
        else
        {
            playerRB.drag = 100f; // or some other value larger than the small one
        }
    }
What we're doing now is checking to see if we have a non-negligible (basically 0) amount of movement to apply, and if we are then we're not going to apply drag because then we'd be slowing our positive acceleration and that makes it difficult to predict what values you should have when setting up the game.
Since we now have no drag on the object, it *should* drift according to physics. That's what you're currently seeing. If we don't want that we can check if we have a non-negligible (basically 0) amount of velocity, and align that to our desired movement direction. Don't forget that `movement` is in local space still, and `playerRB.velocity` is in world space.
Then since we have movement to apply we should apply our *local* movement to our body using `AddRelativeVelocity` to continue accelerating in the desired direction. Currently this keeps going forever but you probably want to clamp your maximum speed eventually.
If we aren't applying movement, we want physics to apply drag and slow down the player. If we make physics do the work you should get reasonable(ish) acceleration to speed up and slow down (depending on your drag values and applied forces), but since we're ignoring drift you should get immediate turns.

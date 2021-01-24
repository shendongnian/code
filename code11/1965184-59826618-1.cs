using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour {
public GameObject player;        //Public variable to store a reference to the player game object
public bool followY = false;
private Vector3 offset;            //Private variable to store the offset distance between the player and camera
// Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
// LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(followY)
          {
          transform.position = player.transform.position + offset; // we should follow the player Y movements, so we copy the entire position vector
          }
        else
          {
          transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + offset; // we just copy the X and Z values
          }
    }
}
Attach this script to the camera and you can enable or disable the Y-axis movement by setting the boolean accordingly. In case you will never need this functionality, just keep the line in the else block.
I hope this will help you!

cs
public GameObject Player;
You have a few other errors in this code.
1. You can't set the `newPos` using a reference to another object outside of a method. Do this in `Update()` instead.
    ```cs
    Vector3 newPos;
    // Update is called once per frame
    void Update () {
        newPos = Player.transform.position;
        // your other code
    }
    ```
2. There is a typo on the last line of update, where the P in Player needs to be capital (that's what you named your variable).
    ```cs
    transform.LookAt(Player.transform);
    ```
EDIT: However, since you only seem to be using the Player.transform anyways, you might as well go ahead and reference the transform component instead.
cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamaraBehaviour : MonoBehaviour {
    public Transform Player;
    public float yOffset = 3.0f;
    public float zOffset = 10.0f;
    Vector3 newPos;
    // Update is called once per frame
    void Update () {
        newPos = Player.position;
        newPos.y = newPos.y + yOffset;
        newPos.z = newPos.z + zOffset;
        transform.position = newPos;
        transform.LookAt(Player.position);
    }
}

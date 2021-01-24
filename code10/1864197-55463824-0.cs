lang-cs
// Add this property to your class definition (so it persists between updates):
private float wheelAxis = 0;
// Delete this line:
var zoomDelta = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
// And put these three new lines in its place:
wheelAxis += Input.GetAxis("Mouse ScrollWheel");
wheelAxis = Mathf.MoveTowards(wheelTotal, 0f, Time.deltaTime);
var zoomDelta = Mathf.Clamp(wheelAxis, -0.05f, 0.05f) * zoomSpeed * Time.deltaTime;
Right, so we do a few things here. Every update, we add the current scrollwheel values to our `wheelAxis`. Next, we apply the current `Time.deltatime` as "gravity" via the `Mathf.MoveTowards()` function. Finally, we call what's mostly just your old `zoomDelta` code with a simple modification: We constrain the `wheelAxis` with `Mathf.Clamp` to try and regulate how fast the zooming can happen.
You can modify this code in a couple of ways. If you multiply the `Time.deltaTime` parameter you can affect how long your input will "persist" for. If you mess with the `Mathf.Clamp()` values, you'll get faster or slower zooming. All in all though, if you just want a smooth zoom with minimal changes to your code, that's probably your best bet.
So!
Now that we've done that, let's talk about your code, and how you're approaching the problem, and see if we can't find a somewhat cleaner solution.
Getting a good camera working is surprisingly non-trivial. Your code looks like a lot of code I see that tries to solve a complex problem: It looks like you added some feature, and then tested it, and found some edge cases where it fell apart, and then patched those cases, and then tried to implement a new feature on top of the old code, but it kinda broke in various other ways, etc etc, and what we've got at this point is a bit messy.
The biggest issue with your code is that the camera's *position* and the camera's *rotation* are closely tied together. When working with characters, this is usually fine, but when working with a camera, you want to break this up. Think about where the camera *is* and what the camera is *looking at* as very separate things to keep track of.
So here's a working camera script that you should be able to plug in and just run with:
lang-cs
using UnityEngine;
public class RTSCamera : MonoBehaviour
{
    public float zoomSpeed = 100f;
    public float zoomTime = 0.1f;
    
    public float maxHeight = 100f;
    public float minHeight = 20f;
    
    public float focusHeight = 10f;
    public float focusDistance = 20f;
    public int panBorder = 25;
    public float dragPanSpeed = 25f;
    public float edgePanSpeed = 25f;
    public float keyPanSpeed = 25f;
    
    private float zoomVelocity = 0f;
    private float targetHeight;
    void Start()
    {
        // Start zoomed out
        targetHeight = maxHeight;
    }
    void Update()
    {
        var newPosition = transform.position;
        // First, calculate the height we want the camera to be at
        targetHeight += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1f;
        targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight);
        // Then, interpolate smoothly towards that height
        newPosition.y = Mathf.SmoothDamp(transform.position.y, targetHeight, ref zoomVelocity, zoomTime);
        // Always pan the camera using the keys
        var pan = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * keyPanSpeed * Time.deltaTime;
        // Optionally pan the camera by either dragging with middle mouse or when the cursor touches the screen border
        if (Input.GetMouseButton(2)) {
            pan += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * dragPanSpeed * Time.deltaTime;
        } else {
            var border = Vector2.zero;
            if (Input.mousePosition.x < panBorder) border.x += 1f;
            if (Input.mousePosition.x >= Screen.width - panBorder) border.x -= 1f;
            if (Input.mousePosition.y < panBorder) border.y += 1f;
            if (Input.mousePosition.y > Screen.height - panBorder) border.y -= 1f;
            pan += border * edgePanSpeed * Time.deltaTime;
        }
        newPosition.x += pan.x;
        newPosition.z += pan.y;
        var focusPosition = new Vector3(newPosition.x, focusHeight, newPosition.z + focusDistance);
        transform.position = newPosition;
        transform.LookAt(focusPosition);
    }
}
While I encourage you to go through it in your own time, I'm not going to drag you through every inch of it. Instead, I'll just go over the main crux.
The key idea here is that rather than controlling the camera's height and orientation directly, we just let the scrollwheel dictate where *want* the camera's height to be, and then we use `Mathf.SmoothDamp()` to move the camera smoothly into that position over several frames. (Unity has many useful functions like this. Consider `Mathf.MoveTowards()` for an alternative interpolation method.) At the very end, rather than trying to fiddle with the camera's rotation values directly, we just pick a point in front of us near the ground and point the camera at that spot directly.
By keeping the camera's position and orientation completely independent of each other, as well as separating out the "animation" of the camera's height, we avoid a lot of headaches and eliminate a lot of potential for messy interwoven bugs.
I hope that helps.
  [1]: https://unity3d.com/learn/tutorials/topics/animation/using-cinemachine-getting-started

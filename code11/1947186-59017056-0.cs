public class MyPainter : MonoBehaviour {
    [SerializeField, Tooltip("The prefab to paint")]
    private GameObject toPaint;
    [SerializeField, Tooltip("How far does the cursor have to move in order to paint the next object?")]
    private float paintDistanceThreshold;
    private bool isPainting;
    /// <summary>
    /// How much distance did the cursor travelled since last paint.
    /// </summary>
    private float cursorDistanceTravelledSinceLastPaint;
    private Vector2 lastCursorPosition;
    private Camera mainCameraRef;
    private void Awake() {
        isPainting = false;
        // Btw, cache the main camera. Repeated calls to 'Camera.main' is expensive.
        mainCameraRef = Camera.main;
        cursorDistanceTravelledSinceLastPaint = 0f;
    }
    private void Update() {
        // Mouse button pressed, start painting.
        if (Input.GetMouseButtonDown(0)) {
            PaintAtCurrentCursorPosition();
            isPainting = true;
        }
        if (isPainting) {
            cursorDistanceTravelledSinceLastPaint += Vector2.Distance(Input.mousePosition, lastCursorPosition);
            if (cursorDistanceTravelledSinceLastPaint >= paintDistanceThreshold) {
                PaintAtCurrentCursorPosition();
            }
        }
        // Mouse button lifted, stop painting.
        if (Input.GetMouseButtonUp(0)) {
            isPainting = false;
        }
        lastCursorPosition = Input.mousePosition;
    }
    private void PaintAtCurrentCursorPosition() {
        Vector3 newPos = mainCameraRef.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        Instantiate(toPaint, newPos, Quaternion.identity);
        cursorDistanceTravelledSinceLastPaint = 0f;
    }
}
Basically, it starts painting `OnMouseDown`.<br>
When the mouse cursor travels a certain amount of distance (`paintDistanceThreshold`), it will paint another object.
Stops painting `OnMouseUp`.
Though one issue you might encounter is that when your mouse cursor intercepts a point where you have painted before, it will paint on that point again.<Br><br>
>  can I make list (ArrayList) of instantiated objects and then destroy objects (points) which has a same position?
It will mostly work if your painter is pixel/grid based. Otherwise, the coordinates needs to be rounded off for it to work accurately.<br><br>
That said, most painting applications today uses pixel-based. I would highly suggest that you make your painter paint by pixel/grid rather than world coordinates.<br>
This way, you can avoid a lot of the issues that I mentioned earlier.

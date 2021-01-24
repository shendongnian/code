    public class DragCamera : MonoBehaviour {
            #if UNITY_EDITOR
    
            bool isDragging = false;
            float startMouseX;
            float startMouseY;
            Camera cam;
            void Start () {
    
                cam = GetComponent<Camera>();
            }
            void Update () {
    
                if(Input.touchCount > 0 && !isDragging )
                {                
    
                    isDragging = true;
    
                    // save the mouse starting position
                    startMouseX = Input.GetTouch(0).position.x;
                    startMouseY = Input.GetTouch(0).position.y;
                }
                else if(Input.touchCount == 0 && isDragging)
                {                
                    // set the flag to false
                    isDragging = false;
                }
            }
    
            void LateUpdate()
            {
    
                if(isDragging)
                {
    
                    float endMouseX = Input.GetTouch(0).position.x;
                    float endMouseY = Input.GetTouch(0).position.y;
    
                    //Difference (in screen coordinates)
                    float diffX = endMouseX - startMouseX;
                    float diffY = endMouseY - startMouseY;
    
    
                    float newCenterX = Screen.width / 2 + diffX;
                    float newCenterY = Screen.height / 2 + diffY;
    
                    Vector3 LookHerePoint = cam.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, cam.nearClipPlane));
    
                    //Make our camera look at the "LookHerePoint"
                    transform.LookAt(LookHerePoint);
    
                    //starting position for the next call
                    startMouseX = endMouseX;
                    startMouseY = endMouseY;
                }
            }
    
            #endif
        }
    }

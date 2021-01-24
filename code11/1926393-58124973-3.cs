public float swipeSpeed = 0.002f;
#if UNITY_EDITOR
    private Vector3 lastMousePos;
#endif
private void Update 
{
    bool touch;
    Vector3 deltaPosition;
    #if UNITY_EDITOR
        touch = Input.GetMouseButton(0);
        if(touch)
        {
            deltaPosition = Input.mousePosition - lastMousePos;
            lastMousePos = Input.mousePosition;
        }
    #else
        touch = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved);
        if(touch)
        {
            deltaPosition = Input.GetTouch(0).deltaPosition
        }
    #endif
    
    if(touch)
    {
        transform.Translate( 0f,0f, -deltaPosition.x * swipespeed);
    }
}
Update: Since apparently telling someone to drop their ego gets my comment deleted, no this is not a duplicate of his/her answer. This is best practice for multi-platform development and differs significantly from his/her answer.
  [1]: https://docs.unity3d.com/Manual/PlatformDependentCompilation.html

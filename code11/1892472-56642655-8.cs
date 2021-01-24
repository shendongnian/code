    // set desired move duration in seconds
    public float moveDuration = 1;
    
    private bool isMoving;
    
    privtae void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(transform.position + Vector3.right * 1.5f, moveDuration);
        }
        
        if (!isMoving && Input.GetMouseButtonDown(1))
        {
            StartCoroutine(transform.position - Vector3.right * 1.5f, moveDuration);
        }
    }
    
    private IEnumerator Move(Vector3 targetPosition, float duration)
    {
        if(isMoving) yield break;
    
        isMoving = true;
    
        var startPosition = transform.position;
        var passedTime = 0f;
    
        do
        {
            // This would move the object with a linear speed
            var lerpfactor = passedTime / duration;
    
            // This is a cool trick to simply ease-in and ease-out
            // the move speed 
            var smoothLerpfactor = Mathf.SmoothStep(0, 1, lerpfactor);
    
            transform.position = Vector3.Lerp(startPosition, targetPosition, smoothLerpfactor);
    
            // increase the passedTime by the time 
            // that passed since the last frame
            passedTime += Time.deltaTime;
            // Return to the main thread, render this frame and go on
            // from here in the next frame
            yield return null;
    
        } while (passedTime < duration);
    
        // just like before set the target position just to avoid any
        // under shooting
        transform.position = targetPosition;
    
        isMoving = false;
    }

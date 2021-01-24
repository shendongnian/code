    StartCoroutine(Rotate(90, 2));
    // flag to avoid concurrnt routines
    private bool isRotating;
    private IEnumerator Rotate(float degrees, float duration)
    {
        if(isRotating) yield break;
        isRotating = true;
        var passedTime = 0f;
        var startRotation = transform.rotation;
        var targetRotation = transform.rotation * Quaternion.Euler(0, 0, degrees);
    
        while(passedTime < duration)
        {
            // this will always be a linear value between 0 and 1
            var lerpFactor = passedTime / duration;
            //optionally you can add ease-in and ease-out
            //lerpFactor = Mathf.SmoothStep(0, 1, lerFactor);
    
            // This rotates linear 
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, lerpFactor);
            // OR This already rotates smoothed using a spherical interpolation
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, lerpFactor);
    
            // Here you see it is again - Time.deltaTime
            // increase the passedTime by the time passed since last frame
            // to avoid overshooting we clamp it
            timePassed += Mathf.Min(duration - passedTime, Time.deltaTime);
            // yield in a Coroutine reads like
            // pause here, render this frame and continue from here in the next frame
            yield return null;
        }
    
        // just to be sure
        transform.rotation = targetRotation;
        isRotating = false;
    }

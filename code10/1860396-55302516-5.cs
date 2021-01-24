    // adjust this in the Inspector
    public float totalMovementTime = 0.3f;
    public IEnumerator MoveForward()
    {
        var originalPosition = transform.position;
        var DestinationF = transform.position + transform.forward * DistanceF;
        var currentDuration = 0.0f;
        while (currentDuration < totalMovementTime)
        {
            transform.position = Vector3.Lerp(originalPosition, DestinationF, currentDuration / totalMovementTime);
            currentDuration += Time.deltaTime;
            yield return null;
        }
        // to be really sure set a fixed position in the end
        transform.position = DestinationF;
    }
    

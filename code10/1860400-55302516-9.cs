    // adjust these in the Inspector
    public float totalMovementTime = 0.3f;
    public float MoveDistance;
    public IEnumerator Move(Vector3 direction)
    {
        var originalPosition = transform.position;
        var destination = transform.position + direction * MoveDistance;
        // here you could make it even more accurate
        // by moving allways with the same speed 
        // regardless how far the object is from the target
        //var moveDuration = totalMovementTime * Vector3.Distance(transform.position, destinaton);
        // and than replacing totalMovementTime with moveDuration 
        var currentDuration = 0.0f;
        while (currentDuration < totalMovementTime)
        {
            transform.position = Vector3.Lerp(originalPosition, destination, currentDuration / totalMovementTime);
            currentDuration += Time.deltaTime;
            yield return null;
        }
        // to be really sure set a fixed position in the end
        transform.position = destinaton;
    }
    

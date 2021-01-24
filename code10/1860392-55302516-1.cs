    public IEnumerator MoveForward()
    {
        // you probably want to make this a const or 
        // at least global class veriable
        var totalMovementTime = 0.3f;
        var originalPosition = transform.position;
        var DestinationF = new Vector3(transform.position.x, transform.position.y, transform.position.z + DistanceF); 
        while (currentDuration < totalMovementTime)
        {
            float currentMovementTimeF = Time.deltaTime;
            transform.position = Vector3.Lerp(originalPosition, DestinationF, currentDuration / totalMovementTime);
            currentDuration += Time.deltaTime;
            yield return null;
        }
        // to be really sure set a fixed position in the end
        transform.position = DestinationF;
    }
    

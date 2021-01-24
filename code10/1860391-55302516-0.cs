    // adjust this in the Inspector
    public float speed;
    public IEnumerator MoveForward()
    {
        Vector3 DestinationF = new Vector3(transform.position.x, transform.position.y, transform.position.z + DistanceF); 
        while (Vector3.Distance(transform.localPosition, DestinationF) > 0)
        {
            float currentMovementTimeF = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, DestinationF, currentMovementTimeF * speed);
            yield return null;
        }
    }
    

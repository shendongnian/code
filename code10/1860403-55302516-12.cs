    // adjust these in the Inspector
    public float speed;
    public float MoveDistance;
    public IEnumerator Move(Vector3 direction)
    {
        var destinaton = transform.position + direction * MoveDistance; 
        while (Vector3.Distance(transform.position, destinaton) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, MoveDistance, Time.deltaTime* speed);
            yield return null;
        }
    }

    public void coroutineStarter()
    {
        var targetPosition = transform.position + Vector3.left;
        StartCoroutine(OnClick(targetPosition));
    }
    IEnumerator OnClick(Vector3 targetPosition)
    {
        while (transform.position.x != targetPosition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            // Important! Tells Unity to pause here, render this frame
            // and continue from here in the next frame
            yield return null;
        }
        // When done set the position fixed once
        // since == has a precision of 0.00001 so it never reaches an exact position
        transform.position = targetPosition;
    }
---

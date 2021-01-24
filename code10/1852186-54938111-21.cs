    private Quaternion lastRotation;
    private void Update()
    {
        if (target != null && !Mathf.Approximately(timer, 1.0f))
        {
            transform.rotation = Quaternion.Slerp(lastRotation, Quaternion.LookRotation((target.position - transform.position).normalized), timer);
            timer += Time.deltaTime * RotationSpeed;
        }
        else
        {
            lastRotation = transform.rotation;
        }
    }

    public float directionChangeTimer = 5f;
    public float anglesPerSecond = 1f;
    public float accelerateSpeed;
    private void Start()
    {
        StartCoroutine(RandomRotations);
    }
    private void IEnumerator RandomRotations()
    {
        while(true)
        {
            // wait for directionChangeTimer seconds
            yield return new WaitForSeconds(directionChangeTimer);
            // get currentRotation
            var startRot = transform.rotation;
            // pick the next random angle
            var randomAngleAdd = Random.Range(-5f, 5f);
            // store already rotated angle
            var alreadyRotated = 0f;
            // over time add the rotation
            do
            {
                // prevent overshooting
                var addRotation = Mathf.Min(Mathf.Abs(randomAngleAdd) - alreadyRotated, Time.deltaTime * anglesPerSecond);
                // rotate a bit in the given direction
                transform.Rotate(0, 0, addRotation * Mathf.Sign(randomAngleAdd));
                alreadyRotated += addRotation;
                yield return null;
            }
            while(alreadyRotated < Mathf.Abs(randomAngleAdd));
        }
    }

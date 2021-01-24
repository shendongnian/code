    public float MovementAmplitude = 0.1f;
    public float MovementFrequency = 2.25f;
    private void LateUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Cos(transform.position.z * MovementFrequency) * MovementAmplitude,
            transform.position.z
        );
    }

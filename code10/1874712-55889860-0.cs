    public float start;
    public float end;
    // Change in units/sec.
    public float speed = 1.0F;
    private float startTime;
    // Total distance between the start and end.
    private float length = Mathf.Abs(start - end);
    public healthBarLength = start;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        float delta = (Time.time - startTime) * speed;
        float fracDelta = delta / length;
        healthBarLength = Vector3.Lerp(start, end, fracDelta);
    }

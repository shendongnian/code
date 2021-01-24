    // would even be better if you can already reference this in the Inspector
    [SerializeField] private Camera _camera;
    public Image gridImage;
    public float minSize;
    public float maxSize;
    private float desiredSize;
    private void Awake()
    {
        if (!_camera) _camera = GetComponent<Camera>();
        // initialize the desired size with the current one
        desiredSize = Mathf.Clamp(_camera.orthographicSize, minSize, maxSize);
        // do it once on game start
        UpdateImage(desiredSize);
    }
    // Update is called once per frame
    private void Update()
    {
        var currentSize = _camera.orthographicSize;
        desiredSize -= Input.mouseScrollDelta.y * 3;
        //Clamp between min and max
        desiredSize = Mathf.Clamp(desiredSize, minSize, maxSize);
        // is the scaling already done?
        // -> Skip unnecessary changes/updates
        if (Mathf.Approximately(desiredSize, currentSize)) return;
        //Smoothly interpolates to desired size
        _camera.orthographicSize = Mathf.Lerp(currentSize, desiredSize, 5f * Time.deltaTime);
        UpdateImage(_camera.orthographicSize);
    }
    private void UpdateImage(float size)
    {
        //Change pixels per unit multiplier to half of camera's size (with only 1 decimal char)
        gridImage.pixelsPerUnitMultiplier = Mathf.Round(size / 2 * 10f) / 10f;
        gridImage.SetVerticesDirty();
    }

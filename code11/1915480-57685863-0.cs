    // would even be better if you can already reference this in the Inspector
    [SerializeField] private Camera _camera;
    public Image gridImage;
    public float minSize;
    public float maxSize;
    // use for comparing and avoid unnecessary image updates
    private float lastSize;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
      
        // do it once on game start
        UpdateImage(camera.orthographicSize);
    }
    // Update is called once per frame
    private void Update()
    {
        var currentSize = camera.orthographicSize;
        var desiredSize = currentSize - Input.mouseScrollDelta.y * 3;
        //Clamp between min and max
        desiredSize = Mathf.Clamp(desiredSize, minSize, maxSize);
        // is the scaling already done?
        // -> Skip unnecessary changes/updates
        if (Mathf.Approximately(desiredSize, currentSize)) return;
        //Smoothly interpolates to desired size
        camera.orthographicSize = Mathf.Lerp(currentSize, desiredSize, 5f * Time.deltaTime);
        UpdateImage(camera.orthographicSize);
    }
    private void UpdateImage(float size)
    {
        //Change pixels per unit multiplier to half of camera's size (with only 1 decimal char)
        gridImage.pixelsPerUnitMultiplier = Mathf.Round(size / 2 * 10f) / 10f;
        gridImage.SetVerticesDirty();
    }

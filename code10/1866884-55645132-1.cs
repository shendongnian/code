    public GameObject markerPrefab;
    [SerializeField] private Canvas _canvas;
    private void Awake()
    {
        // If no canvas is provided get it by tag
        if (!_canvas) _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Instantiate(markerPrefab, Input.mousePosition, Quaternion.identity, _canvas.transform);
        }
    }

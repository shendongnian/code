    public GameObject refButton;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject button = Instantiate(refButton, Input.mousePosition,Quaternion.identity);
            button.transform.SetParent(canvas.transform);
        }
    }

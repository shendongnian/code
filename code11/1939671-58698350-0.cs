    [SerializeField] private Camera _camera;
    private void Awake ()
    {
        if(!_camera) _camera = Camera.main;
    }
    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        if (Physics.Raycast(ray, out hit) && hit.gameObject.CompareTag("Cylinder"))
        {
            // First click -> select object
            if(Input.GetMouseButtonDown(0) && !selected)
            {
                selected = hit.transform.gameObject;
            }
            // button stays pressed > move object
            else if (selected && Input.GetMouseButton(0))
            {
                selected.transform.position = hit.point;
            }
            // Second click release object
            else if(selected && Input.GetMouseButtonDown(0))
            {
                selected = null;
            }
        }
    }

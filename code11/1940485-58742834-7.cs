    private bool isPressed;
    private void OnGUI()
    {
        isPressed = GUI.Button(new Rect(165, 300, 150, 350), "right");
    }
    private void Update()
    {  
        if(!isPressed) return;
     
        var pos = transform.position;
        var targetPosition = pos + Vector3.right * 0.5f;
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }

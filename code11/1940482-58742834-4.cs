    private bool isPressed;
    private void OnGUI()
    {
        isPressed = GUI.Button(new Rect(165, 300, 150, 350), "right");
    }
    private void Update()
    {  
        if(!isPressed) return;
     
        var pos = transform.position;
        float rightMovement = pos.x + 0.5f;
        Vector3 targetPosition = new Vector3(rightMovement, transform.position.y, transform.position.z);
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }

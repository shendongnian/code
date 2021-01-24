    void Update()
    {
        Vector3 curPos = transform.position;
        // after mouse has been left clicked and user presses spacebar or up arrow keys to carry out animations.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //defining targetPos as the mouse click position
                Vector3 targetPos = Input.mousePosition;
                //outputting to console target position
                Debug.Log("Mouse Position " + targetPos);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    //newPos is the position of where miffy is meant to go.
                    newPos = new Vector3(hit.point.x, 0.1199974f, hit.point.z);
                    //setting isMiffyMoving to true to carry out miffyMove() actions
                    isMiffyMoving = true;
                }
                //if statements to detmine miffy's direction when shes moving and output to console.
                if (targetPos.x < curPos.x)
                {
                    Debug.Log("Miffy is going left");
                    left = true;
                    isIdle = false;
                }
                else if (targetPos.x > curPos.x)
                {
                    Debug.Log("Miffy is going right");
                    left = false;
                    isIdle = false;
                }
                if (targetPos.z < curPos.z)
                {
                    Debug.Log("Miffy is going backward");
                    forward = false;
                    isIdle = false;
                }
                else if (targetPos.z > curPos.z)
                {
                    Debug.Log("Miffy is going forward");
                    forward = true;
                    isIdle = false;
                }
                //setting isIdle to true is miffy is not moving
                if (isIdle)
                {
                    Debug.Log("Miffy is idle");
                    isIdle = true;
                }
            }
        }
        ////when up arrow key has been pressed animation stored in SpinJump will play
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.Play("SpinJump");
            Debug.Log("Working");
        }
        ////if spacebar has been pressed animation stored in cheer with play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("cheer");
            Debug.Log("Working");
        }
    }

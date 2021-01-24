    private bool _swiping;
    private bool _swipingDown;
    private Vector3 _previousSwipePosition;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousSwipePosition = Input.mousePosition;
            _swiping = true;
            Debug.log("Started Swipe");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _swiping = false;
            Debug.log("Finished Swipe");
        }
    
        if (_swiping)
        {
            Vector3 newPosition = Input.mousePosition;
            if (newPosition.y < _previousSwipePosition.y)
            {
                if (!_swipingDown)
                {
                    Debug.Log("Started Swipe Down");
                    _swipingDown = true;
                }
            }
            if (newPosition.y> _previousSwipePosition.y)
            {
                if (_swipingDown)
                {
                    Debug.Log("Started Swipe Up");
                    _swipingDown = false;
                }
            }
            _previousSwipePosition = newPosition;
        }
    }

        private Vector3 _mouseStartPosition;
        
        // remove OnMouseExit
        // remove OnMouseUp
        // remove OnMouseDrag
        private void OnMouseDown()
        {
            if (_isObjectSelected) return;
            _mouseStartPosition = Input.mousePosition;
            _isObjectSelected = true;
        }
        
        private void WhileDragging()
        {
            if (!_isObjectSelected) return;
            //Debug.LogError("Mouse drag");
            var currentPosition = Input.mousePosition;
            var offsetPos = currentPosition - _mouseStartPosition;
            var distCovered = offsetPos.y / _journeyLength;
           UpdateJourney(distCovered);
        }
      
        // instead of using OnMouseExit, OnMouseUp and OnMouseDrag rather 
        // do it in Update
        private void Update()
        {
            if (_isObjectSelected)
            {
                // use this to detect mouse up instead
                if (Input.GetMouseButtonUp(0))
                {
                    _isObjectSelected = false;
                }
            }
            // call it here instead of using OnMouseDrag
            WhileDragging();
            
            ...
        }
    

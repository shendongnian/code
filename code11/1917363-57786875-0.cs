        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    _mouseStartPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    _isObjectSelected = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_isObjectSelected)
            {
                _isObjectSelected = false;
                //Debug.LogError("Gettting false");
            }
        }
        if (_isObjectSelected)
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            //Debug.LogError(mousePosition + " , " + transform.position);
            Vector3 distanceVector = mousePosition - _mouseStartPosition;
            float distance = distanceVector.magnitude;
            Vector3 normalDistance = distanceVector.normalized;
            
            //Debug.LogError(distance + " " + normalDistance);
            if (distance > 0.1f)
            {
                if (normalDistance.y > 0.1f)
                {
                    _currentTime -= Time.deltaTime * distance * 3f;
                    _shieldMovement.UpdateJourney(_currentTime);
                }
                else if (normalDistance.x > 0.1f)
                {
                    _currentTime += Time.deltaTime * distance * 3f;
                    _shieldMovement.UpdateJourney(_currentTime);
                }
            }
            _mouseStartPosition = mousePosition;
        }
so far, i did this in update method, its not perfect but working ok.

    void Update()
    {
        if(active)
        {
            if(!positionSet)
            {
                endPosition = new Vector3(transform.position.x, transform.position.y - 200, transform.position.z);
                positionSet = true;
            }
            var step = 250 * Time.deltaTime;
            if (Vector3.Distance(transform.position, endPosition) < step) {
              transform.position = endPosition;
            }else {
              transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
            }
        }
    }

    private float Perc;
    
    private void Update()
    {
        GetPercByLerpTime(); // Update before it moves
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == tag)
            {
                transform.position = Vector3.Lerp(startPos, endPos, Perc);
            }
            else
            {
                transform.position = Vector3.Lerp(endPos, startPos, Perc);
            }
        }
    
        // Or you can update your 'Perc' here.
    }
    
    private void UpdatePercByLerpTime(){
      currentLerpTime += Time.deltaTime;
      if(currentLerpTime >= lerpTime)
      {
          currentLerpTime = lerpTime;
      }
    
      Perc = currentLerpTime / lerpTime;
    } 

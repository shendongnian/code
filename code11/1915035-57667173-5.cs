    private float Perc;
    
    private void Update() {
        UpdatePercByLerpTime();
    
        if (MouseRaycastHitThisObject()) {
          transform.position = Vector3.Lerp(startPos, endPos, Perc);
        } else {
          transform.position = Vector3.Lerp(endPos, startPos, Perc);
        }
        
        // Or you can update your 'Perc' here.
    }
    
    // True if the raycastfrom the mouse position hits this object
    private bool MouseRaycastHitThisObject(){
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      
      if (Physics.Raycast(ray, out hit, 100)) {
          return hit.transform.tag == tag;
      }
    
      // Raycast did not hit anything; Player's mouse is not hovering over anything.
      return false;
    }
    
    private void UpdatePercByLerpTime(){
      currentLerpTime += Time.deltaTime;
      if(currentLerpTime >= lerpTime) {
          currentLerpTime = lerpTime;
      }
    
      Perc = currentLerpTime / lerpTime;
    }

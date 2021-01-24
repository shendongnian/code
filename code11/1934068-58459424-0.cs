    function Update () {
             if (Input.GetMouseButtonDown(0)) {
                 var hit: RaycastHit;
                 var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                 
                 if (Physics.Raycast(ray, hit)) {
                     if (hit.transform.gameObject == gameObject ){
                          gameObject.renderer.material.color = new Color(1,1,1);
                     }
                 }
             }

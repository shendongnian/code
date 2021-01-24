    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null){
                Material mymat = hit.collider.gameObject.GetComponent<Renderer>().material;
                mymat.SetColor("_EmissionColor", Color.red);
            }
        }
    }

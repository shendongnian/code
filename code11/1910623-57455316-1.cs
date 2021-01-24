    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.tag == "Clone") return;
        var corners = GetComponent<RectTransform>().GetWorldCorners();
        
        var bottomLeft = corners[0];
        var topRight = corners[2];
        var collider = Physics2D.OverlapArea(bottomLeft, topRight);
        if(collider && collider.gameObject.tag == "Panel")
        {
            Destroy(gameObject);
        }    
        else
        {
            gameObject.SetActive(false);
        }
    }  

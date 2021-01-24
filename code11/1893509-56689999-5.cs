    public void OnBeginDrag (PointerEventData eventData)
    {
        Slot currentSlot = gameObject.GetComponentInParent<Slot>();
        if (currentSlot.isBackpack == false)
        {
            itemBeingDragged = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            itemBeingDragged = null;
        }
    }
    #endregion
    #region IDragHandler implementation
    public void OnDrag (PointerEventData eventData)
    {
        if (itemBeingDragged != null)
            transform.position = eventData.position;
    }
    #endregion
    #region IEndDragHandler implementation
    public void OnEndDrag (PointerEventData eventData)
    {
        if (itemBeingDragged != null)
        {
            itemBeingDragged = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if(transform.parent == startParent)
                transform.position = startPosition;
        }
    }

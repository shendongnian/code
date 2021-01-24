    public float raycastDistance = 10f;
    public float projectDistance = 4f;
    public void OnEndDrag(PointerEventData eventData)
    {
        var spawned = Instantiate(prefab);
        
        var ray = Camera.main.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance)
        {
            spawned.transform.position = hit.point;
        }
        else
        {
            spawned.transform.position = Camera.main.transform.position + (ray * projectDistance);
        }
    }

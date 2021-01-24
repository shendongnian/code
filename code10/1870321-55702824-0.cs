    private LineRenderer lineRenderer;
    public void AddPosition(Vector3 position)
    {
        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
    }
    public void SetPositions(Vector3[] positionArray)
    {
        lineRenderer.SetPositions(positionArray);
    }
    

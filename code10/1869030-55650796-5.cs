    private void Start()
    {
        var lineRenderer = GetComponent<LineRenderer>();
        var image = GetComponentInParent<RectTransform>();
        // get the Unity worldspace coordinates of the images corners
        // note: to get the scales like that ofcourse only works
        // if the image is never rotated!
        var worlsCorners = new Vector3[4];
        image.GetWorldCorners(worlsCorners);
        var imageWorldSize = new Vector2(Mathf.Abs(worlsCorners[0].x - worlsCorners[2].x), Mathf.Abs(worlsCorners[1].y - worlsCorners[3].y));
        var positions = new Vector3[lineRenderer.positionCount];
        var pointnum = lineRenderer.GetPositions(positions);
        for (var i = 0; i < pointnum; i++)
        {
            positions[i] = positions[i] * imageWorldSize.x;
        }
        lineRenderer.SetPositions(positions);
    }

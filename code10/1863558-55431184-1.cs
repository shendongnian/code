    public GameObject LineDrawPrefab;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> edgePoints;
    private GameObject activeLineGameObject;
    private List<GameObject> lineGameObjects;
        private void StartLine(Vector3 start, Color color)
        {
            var targetPos = new Vector3 { x = start.x, y = start.y, z = 0.1f };
    
            drawing = true;
            activeLineGameObject = Instantiate(LineDrawPrefab, Vector3.zero, Quaternion.identity);
            lineGameObjects.Add(activeLineGameObject);
    
            lineRenderer = activeLineGameObject.GetComponent<LineRenderer>();
            edgeCollider = activeLineGameObject.GetComponent<EdgeCollider2D>();
            lineRenderer.sortingOrder = 1;
            lineRenderer.material = LineRendererMaterial;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;
            lineRenderer.SetPosition(0, targetPos);
            lineRenderer.SetPosition(1, targetPos);
    
            edgePoints.Clear();
            edgePoints.Add(targetPos);
            edgeCollider.points = edgePoints.ToArray();
        }
    
        private void ExtendLine(Vector3 nextpoint)
        {
            if (lineRenderer == null))
            {
                StartLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), color);
                return;
            }
            var targetPos = new Vector3 { x = nextpoint.x, y = nextpoint.y, z = 0.1f };
    
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, lineRenderer.transform.position = targetPos); // manipulate position to avoid the collider from spawning out of the object.
    
            edgePoints.Add(nextpoint);
            edgeCollider.points = edgePoints.ToArray();
            activeLineGameObject.transform.position = Vector3.zero; // reset position
        }

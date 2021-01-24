    private void PlaceObjects()
    {
        var center = RectangleParent.GetComponent<MeshRenderer>().bounds.center;
        var size = RectangleParent.GetComponent<MeshRenderer>().bounds.size;
        var corner = -new Vector3(size.x / 2, 0, size.z / 2);
        var stepX = size.x / (maxColumns + 1);
        var stepZ = size.z / (maxRows + 2);
        var placedObjects = NumberOfObjectsToPlace;
        for (var i = 0; i < placedObjects; i++)
        {
            var cube = Instantiate(CubePrefab);
            cube.transform.parent = RectangleParent.transform;
            cube.transform.localRotation = Quaternion.identity;
            cube.transform.localPosition = new Vector3(
                                               corner.x / RectangleParent.transform.localScale.x,
                                               corner.y / RectangleParent.transform.localScale.y,
                                               corner.z / RectangleParent.transform.localScale.z
                                           )
                                           + new Vector3(
                                               stepX / RectangleParent.transform.localScale.x,
                                               center.y + 0.15f,
                                               (stepZ * 1.5f + i * stepZ) / RectangleParent.transform.localScale.z
                                           );
            cube.transform.localScale = new Vector3(
                                            1 / RectangleParent.transform.localScale.x,
                                            1 / RectangleParent.transform.localScale.y,
                                            1 / RectangleParent.transform.localScale.z
                                        );
            if (i != maxRows - 1) continue;
            i -= maxRows;
            placedObjects -= maxRows;
            stepX += size.x / (maxColumns + 1);
        }
    }

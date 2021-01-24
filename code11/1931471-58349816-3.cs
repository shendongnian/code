    public MeshFilter[] meshFilters;
    private void OnDrawGizmos()
    {
        var vertices = new List<Vector3>();
        foreach (var meshFilter in meshFilters)
        {
            // have to multiply the vertices' positions
            // with the lossyScale and add it to the transform.position 
            vertices.AddRange(meshFilter.sharedMesh.vertices.Select(vertex => meshFilter.transform.position + Vector3.Scale(vertex, meshFilter.transform.lossyScale)));
        }
        var points3d = new Vector3d[vertices.Count];
        for (var i = 0; i < vertices.Count; i++)
        {
            points3d[i] = vertices[i];
        }
        // ...
        // From here the code is the same as above

            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                MeshCollider meshCollider = hit.collider as MeshCollider;
                if (meshCollider != null || meshCollider.sharedMesh != null)
                {
                    mesh = meshCollider.sharedMesh;
                    Vector3[] vertices = mesh.vertices;
                    int[] triangles = mesh.triangles;
                    
                    int[] hittedTriangle = new int[]
                    {
                            mesh.triangles[hit.triangleIndex * 3],
                            mesh.triangles[hit.triangleIndex * 3 + 1],
                            mesh.triangles[hit.triangleIndex * 3 + 2]
                    };
                    
                    for (int i = 0; i < mesh.subMeshCount; i++)
                    {  
                        int[] subMeshTris = mesh.GetTriangles(i);
                        for (int j = 0; j < subMeshTris.Length; j += 3)
                        {
    
                            if (subMeshTris[j] == hittedTriangle[0] &&
                                subMeshTris[j + 1] == hittedTriangle[1] &&
                                subMeshTris[j + 2] == hittedTriangle[2])
                            {
    
                                GetComponent<MeshRenderer>().materials[i].color = Color.cyan;
                            }

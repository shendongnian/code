    public static void WeldVertices(Mesh aMesh, float aMaxDistDelta = 0.01f)
    {
        var aMaxDelta = aMaxDistDelta * aMaxDistDelta;
        var verts = aMesh.vertices;    
        List<int> newVerts = new List<int>();
        int[] map = new int[verts.Length];
        // create mapping and filter duplicates.
        for (int i = 0; i < verts.Length; i++)
        {
            var p = verts[i];
                    
            bool duplicate = false;
            for (int i2 = 0; i2 < newVerts.Count; i2++)
            {
                int a = newVerts[i2];
                if ((verts[a] - p).sqrMagnitude <= aMaxDelta)
                {
                    map[i] = i2;
                    duplicate = true;
                    break;
                }
            }
            if (!duplicate)
            {
                map[i] = newVerts.Count;
                newVerts.Add(i);
            }
        }
        // create new vertices
        var verts2 = new Vector3[newVerts.Count];    
        for (int i = 0; i < newVerts.Count; i++)
        {
            int a = newVerts[i];
            verts2[i] = verts[a];        
        }
        // map the triangle to the new vertices
        var tris = aMesh.triangles;
        for (int i = 0; i < tris.Length; i++)
        {
            tris[i] = map[tris[i]];
        }
        
        aMesh.Clear();       
        aMesh.vertices = verts2;
        aMesh.triangles = tris;                
    }

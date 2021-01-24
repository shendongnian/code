    void CreateMesh()
    {
        Mesh.Clear();
        Mesh.vertices = Vertices.ToArray();
        Mesh.triangles = Triangles.ToArray();
        Mesh.MarkDynamic();
        int len = Mesh.vertices.Length;
        // Set Colors to Mesh
        Color32[] colors = new Color32[] { new Color32(0, 255, 0, 255), new Color32(255, 0, 255, 255), new Color32(0, 0, 255, 255) };
        Color32[] colorsArray = new Color32[len];
 
        System.Random rnd = new System.Random();     
        for (int i = 0; i < len; i++)
            colorsArray[i] = colors[rnd.Next(0, 2)];
        Mesh.colors32 = colorsArray;
    }

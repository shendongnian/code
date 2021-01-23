    class VertexMeshLoaderObj : IVertexMeshLoader
    {
      VertexMesh IVertexMeshLoader.LoadFromFile(string fname) { 
        LoadFromFile(fname);
      }
      public static VertexMesh LoadFromFile(fname) {
        ...
      }
    }

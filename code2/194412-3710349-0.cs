    class VertexMeshLoaderObj : IVertexMeshLoader
    {
      public VertexMesh IVertexMeshLoader.LoadFromFile(string fname) { 
        LoadFromFile(fname);
      }
      public static VertexMesh LoadFromFile(fname) {
        ...
      }
    }

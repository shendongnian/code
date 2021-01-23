    int NumVerts = Objects.Sum(o => o.Vertex.Length);
    int NumIndexes = Objects.Sum(o => o.Index.Length);
    
    VertexPositionColor[] Vertex = new VertexPositionColor[NumVerts];
    int[] Index = new int[NumIndexes];
    
    int VertexOffset = 0;
    int IndexOffset = 0;
    foreach (Object object in Objects)
    {
        for (int v=0; v<object.Vertex.Length; v++)
        {
            Vertex[VertexOffset+v] = object.Vertex[v] + VertexOffset;
        }
    
        for (int i=0; i<object.Index.Length; i++)
        {
            Index[IndexOffset+i] = object.Index[i] + VertexOffset;
        }
    
        VertexOffset += object.Vertex.Length;
        IdnexOffset += object.Index.Length;
    }

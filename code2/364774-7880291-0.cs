    public ReadOnlyCollection<Vertex> Vertices
    {
        get { return _vertices.AsReadOnly(); }
    }
    
    public void Add(Vertex vertex)
    {
        if (vertex.IsValid())
            _vertices.Add(vertex);
    }

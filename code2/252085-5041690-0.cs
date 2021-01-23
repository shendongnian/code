    class Triangle
    {
        List<Vertex> Vertices = new List<Vertex>(); // The triangle owns the vertex collection...
        public void SetVertices(IEnumerable<Vertex> vertices)
        {
            this.Vertices.Clear();
            this.Vertices.AddRange(vertices);
        }
    }

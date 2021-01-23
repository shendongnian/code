    public abstract class VertexBase
    {
        internal Vertex ToVertex()
        {
            // your logic here
        }
    }
    
    public static class OpenGL
    {
        public static void WrappedFunction(VertexBase[] vertices)
        {
            Vertex[] outVertices = new Vertex[vertices.Length];
    
            for(int i = 0; i < vertices.Length; i++)
            {
                outVertices[i] = vertices[i].ToVertex();
            }
    
            OpenGLFunction(outVertices);
        }
    }

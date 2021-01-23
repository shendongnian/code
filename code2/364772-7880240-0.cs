    public class MyVertexList : List<Vertex> 
    {
         public new void Add(Vertex vertex) 
         {
             //validate vertex here
             ....
             ....
             base.AddVertex(vertex);
         }
    }
    public class Graph
    {
        public List<Vertex> Vertices 
        {
            get{ return _vertices}
        }
    } private MyVertexList  _vertices;

    class AdjacencyMatrix
    {
        // representation of the adjacency matrix (AM)
        private readonly int[,] m_Matrix;
        // mapping of character codes to indices in the AM
        private readonly Dictionary<char,int> m_Mapping;
        public AdjacencyMatrix( string edgeVector )
        {
            // using LINQ we can identify and order the distinct characters
            char[] distinctChars = edgeVector.Distinct().OrderBy(x => x);
            m_Mapping = distinctChars.Select((c,i)=>new { Vertex = c, Index = i })
                                     .ToDictionary(x=>x.Vertex, x=>x.Index);
            // build the adjacency cost matrix here...
            // TODO: I leave this up to the reader to complete ... :-D
        }
        // retrieves an entry from within the adjacency matrix given two characters
        public int this[char v1, char v2]
        {
            get { return m_Matrix[m_Mapping[v1], m_Mapping[v2]];
            private set { m_Matrix[m_Mapping[v1], m_Mapping[v2]] = value; }
        }
    }

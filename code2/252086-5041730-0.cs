        /// <summary>
        /// Initialises a new instance of the <see cref="Triangle"/> class that 
        /// contains elements copied from the specified collection.
        /// </summary>
        /// <param name="vertices">
        /// The collection of vertices whose elements are to be copied.
        /// </param>
        public Triangle(IEnumerable<Vertex> vertices)
        {
            this.Vertices = new List<Vertex>(vertices);
        }

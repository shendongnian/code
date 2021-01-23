    class ShapeCollection : IEnumerable<Shape>
    {
       public IEnumerable<Shape> OnlyBoxes
       {
           get { return this.Where(s => s.ShapeType == Box); }
       }
    }

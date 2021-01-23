    class ShapeCollection : IEnumerable<Shape>
    {
       public IEnumerable<Shape> OnlyBox
       {
           get { return this.Where(s => s.ShapeType == Box); }
       }
    }

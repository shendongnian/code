public interface IShapedEnumerator : IEnumerator {
  Shape EnumeratorShape {get; }
}
pblic class ShapedIteratorProxy : IShapedEnumerator {
  private readonly IEnumerator _baseEnumerator;
  private readonly Shape _shape;
  public Shape EnumeratorShape => _shape;
  public ShapedIteratorProxy (Shape shape, IEnumerator baseEnumerator) {
    _baseEnumerator = baseEnumerator;
    _shape = shape;
  }
  public ShapedIteratorProxy (Shape shape, float arg, Func<Shape, float, IEnumerator> operation)
    : this(shape, operation(shape, arg)) 
  {}
  // implementation of IEnumerator that proxy all calls to _baseEnumerator.
  // ...
}
routines.Add(new ShapedIteratorProxy(Shape.SQUARE, Move(Shape.SQUARE, 1)));
routines.Add(new ShapedIteratorProxy(Shape.CIRCLE, 1, Jump);
routines.Add(new ShapedIteratorProxy(Shape.TRIANGLE, 1, Fire);
var shapes = routines.OfType<IShapedEnumerator>()
                     .Select(s=>s.EnumeratorShape)
                     .ToArray();
Please note, that if `routines` contain items that do not implement `IShapedEnumerator`, they will be just skipped.

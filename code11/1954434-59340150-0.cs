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
  // implementation of IEnumerator that proxy all calls to _baseEnumerator.
  // ...
}
public IEnumerator Move(Shape shape, float distance){ 
  // ...
  IEnumerator previousResult= ???  // that's what you returned before.
  return new ShapedIteratorProxy(shape, previousResult)
}
var shapes = routines.OfType<IShapedEnumerator>()
                     .Select(s=>s.EnumeratorShape)
                     .ToArray();
Please note, that if `routines` contain items that do not implement `IShapedEnumerator`, they will be just skipped.

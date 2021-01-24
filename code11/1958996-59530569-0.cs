class GenericStructuralEqualityComparer<T> : EqualityComparer<T>
  where T : System.Collections.IStructuralEquatable
{
  public override bool Equals(T x, T y)
    => System.Collections.StructuralComparisons.StructuralEqualityComparer.Equals(x, y);
  public override int GetHashCode(T obj)
    => System.Collections.StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj);
}
then you can do `SequenceEqauls` on the outer (`List<>`) level:
if (!
  ExpRequestItemsWithSection.SequenceEqual(ActRequestItemsWithSection,
    new GenericStructuralEqualityComparer<string[]>())
  )
Maybe prettier than the `.Zip` solution?

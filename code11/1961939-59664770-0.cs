sealed class StructuralComparer<T> : IEqualityComparer<T>
{
    public static IEqualityComparer<T> Instance { get; } = new StructuralComparer<T>();
    public bool Equals(T x, T y)
        => StructuralComparisons.StructuralEqualityComparer.Equals(x, y);
    public int GetHashCode(T obj)
        => StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj);
}
Then, use it in the `Distinct()` call like this:
TestList = TestList.Distinct(StructuralComparer<ulong[]>.Instance).ToList();

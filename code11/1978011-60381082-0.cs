C#
public static bool ValidateWithBaseSequence<T>(
    IEnumerable<T> baseCollection,
    IEnumerable<T> newCollection,
    IEqualityComparer<T> equalityComparer,
    Func<T, bool> newItemValidator)
{
    using var baseEnumerator = baseCollection.GetEnumerator();
    using var newEnumerator = newCollection.GetEnumerator();
    while (baseEnumerator.MoveNext())
    {
        if (newEnumerator.MoveNext())
        {
            if (!equalityComparer.Equals(
                baseEnumerator.Current, 
                newEnumerator.Current))
            {
                return false;
            }
        }
        else
        {
            throw new InvalidOperationException(
                "New sequence is shorter than base sequence.");
        }
    }
    while (newEnumerator.MoveNext())
    {
        if (!newItemValidator(newEnumerator.Current))
        {
            return false;
        }
    }
    return true;
}

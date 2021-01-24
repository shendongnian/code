C#
public static bool ValidateWithBaseSequence<T>(
    IEnumerable<T> baseSequence,
    IEnumerable<T> newSequence,
    IEqualityComparer<T> equalityComparer,
    Func<T, bool> newItemValidator)
{
    using var baseEnumerator = baseSequence.GetEnumerator();
    using var newEnumerator = newSequence.GetEnumerator();
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
Usage:
C#
var isValid = ValidateWithBaseSequence(x, y, Comparer, item => vaidationFunction(item));

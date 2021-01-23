csharp
public static bool TryFindInnerException<T>(Exception top, out T foundException) where T : Exception
{
    if (top == null)
    {
        foundException = null;
        return false;
    }
    Console.WriteLine(top.GetType());
    if (typeof(T) == top.GetType())
    {
        foundException = (T)top;
        return true;
    }
    return TryFindInnerException<T>(top.InnerException, out foundException);
}

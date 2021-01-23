csharp
public static DateTime? GetAsDateTimeOrDefault(Range cell)
{
    object cellValue = cell.Value;
    if (cellValue is DateTime result)
    {
        return result;
    }
    return null;
}

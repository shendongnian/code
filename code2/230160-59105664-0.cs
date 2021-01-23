csharp
private static DateTime? ParseAsDateTimeOrDefault(Range cell)
{
    object cellValue = cell.Value;
    if (cellValue is DateTime parsedDateTime)
    {
        return parsedDateTime;
    }
    return null;
}

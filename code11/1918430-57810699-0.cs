c#
public abstract class ExcelCellBase
{
    public static string GetAddress(
          int FromRow,
          int FromColumn,
          int ToRow,
          int ToColumn,
          bool FixedFromRow,
          bool FixedFromColumn,
          bool FixedToRow,
          bool FixedToColumn);
}

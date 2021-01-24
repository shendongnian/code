c#
public abstract class ExcelCellBase
{
    public static string GetAddress(
        int Row,
        int Column,
        bool Absolute
    );
    public static string GetAddress(
        int Row,
        bool AbsoluteRow,
        int Column,
        bool AbsoluteCol
    );
    public static string GetAddress(
          int FromRow,
          int FromColumn,
          int ToRow,
          int ToColumn,
          bool FixedFromRow,
          bool FixedFromColumn,
          bool FixedToRow,
          bool FixedToColumn
    );
}

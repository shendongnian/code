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
    /* ... and others, see comments */
}
An extension method could be as easy as this one:
c#
public static class EpPlusExtensions
{
    public static string GetAddress(
        this ExcelRangeBase range,
        bool absoluteRow = false,
        bool absoluteColumn = false)
    {
        return ExcelCellBase.GetAddress(
            range.Start.Row,
            range.Start.Column,
            range.End.Row,
            range.End.Column,
            absoluteRow,
            absoluteColumn,
            absoluteRow,
            absoluteColumn);
    }
}

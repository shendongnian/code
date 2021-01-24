c#
public abstract class Table<TRow> where TRow : Row
{
    //*This is the list of rows i want to be able to send as their base row 
    public List<TRow> derivedRowLst = new List<TRow>();
    public Table()
    {
    }
    public List<TRow> IfindLst()
    {
       return derivedRowLst;
    }
}
//Derive instance of base table class
public class TableInstOne : Table<RowInstOne>
{
}
//Base class for row that all derived rows are guarantee to be of
public abstract class Row
{
}
public class RowInstOne : Row
{
    public RowInstOne() { }
}
public static class Program
{
    public static void Main(string[] args)
    {
        Table<RowInstOne> tblInstOne = new TableInstOne();
        //*This is what I am trying to figure out how to do get this list of base row class from the base table class. Even though it is stored as List<TRow> or derived row class. 
        List<Row> baseLst = tblInstOne.IfindLst().OfType<Row>().ToList();
        List<Row> baseLst2 = tblInstOne.IfindLst().ConvertAll(x => (Row)x);
        List<Row> baseLst3 = tblInstOne.IfindLst().Cast<Row>().ToList();
        IEnumerable<Row> baseLst3 = tblInstOne.IfindLst();
    }
}
Note on the last line I demonstrate the use of the covariant `IEnumerable<T>` interface to avoid any casting or runtime type-checking.

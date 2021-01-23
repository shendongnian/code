    Response.Write(objectExporter.Export(changeRequests, new[]
        {
            changeRequests.GetColumnDef("Change Requested", x => x.ChangeRequested, 12),
            changeRequests.GetColumnDef("Date Created", x => x.DateCreated, 12),
            changeRequests.GetColumnDef("Created By", x => x.Username, 12)
        }));
    // ...
    public class ColumnDefinition<T>
    {
        public string ColumnName { get; private set; }
        public Func<T, object> Selector { get; private set; }
        public int Width { get; private set; }
        public ColumnDefinition(string columnName, Func<T, object> selector, int width)
        {
            ColumnName = columnName;
            Selector = selector;
            Width = width;
        }
    }
    public static class ColumnDefinitionHelper
    {
        public static ColumnDefinition<T> GetColumnDef<T>(this IEnumerable<T> source,
            string columnName, Func<T, object> selector, int width)
        {
            return new ColumnDefinition<T>(columnName, selector, width);
        }
    }
    public class ObjectExporter
    {
        public string Export<T>(
            IEnumerable<T> objects, IEnumerable<ColumnDefinition<T>> columnDefinitions)
        {
            // ...
        }
    }

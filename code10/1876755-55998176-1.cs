public class DataTableAjaxPostModel
{
    public int draw { get; set; }
    public int start { get; set; }
    public int length { get; set; }
    public List<Column> columns { get; set; }
    <b>[ModelBinder(typeof(QueryStringDictSyntaxBinder&lt;search&gt;))]</b>
    <b>public search search { get; set; }</b>
    public List<Order> order { get; set; }
}

    public class SomeClass{
    public string Codigo {get;set;}
    public string Superficie {get;set;}
    public string Error {get;set;}
    }
    .....
    var srcList = new List<SomeClass>();
    .....
    BindingSource bs = new BindingSource();
    bs.DataSource = srcList;
    bs.AllowNew = true;
    bs.AddingNew += new AddingNewEventHandler(BindingSource_AddingNew);
    dataGridViewTennetPaint.AllowUserAddRows = true;
    dataGridViewTennetPaint.DataSource = bs;
    dataGridViewTennetPaint.DataBind();

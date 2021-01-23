    public class MyGridViewModel
    {
        public Guid UniqueId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Description { get; set; }
    }
    void BindDataGrid()
    {
        var gridData = from cm in MyCollection
                       select new MyGridViewModel()
                       {
                           UniqueId = cm.UniqueId,
                           Min = cm.SomeNumber ?? 0,
                           Max = cm.SomeOtherNumber ?? 0,
                           Description = cm.Description
                       };
        this.myGrid.DataSource = gridData;
        this.myGrid.DataBind();
    }

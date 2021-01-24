    public class MyModel
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Month { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var data = new List<MyModel>()
        {
            new MyModel() { Id = 101, Operation = "Alpha", Month = "Jan" },
            new MyModel() { Id = 102, Operation = "Beta", Month = "Feb" },
            new MyModel() { Id = 103, Operation = "Charlie", Month = "Mar" }
        };
        myGridView.DataSource = data;
        myGridView.DataBind();
    }
    protected void myGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var data = myGridView.DataSource as List<MyModel>;
        if (data == null) return;
        myButton.Text = data[myGridView.SelectedIndex].Operation;
    }

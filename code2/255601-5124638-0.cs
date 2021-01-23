    protected void Page_Load(object sender, EventArgs e)
    {
    
        var foos = GetFoos();
        Gridview1.DataSource = foos;
        Gridview1.DataBind();
    
        DetailsView1.DataSource = foos;
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        DetailsView1.DataBind();
    
        DropDownList1.Items.AddRange(foos.Select(f => new ListItem(f.Name, f.Name)).ToArray());
        DropDownList1.Items.Insert(0,new ListItem("-Select-"));
    
           
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedValue = DropDownList1.SelectedValue;
        var foos = GetFoos().Where(f => f.Name == selectedValue);
        Gridview1.DataSource = foos;
        Gridview1.DataBind();
        DetailsView1.DataSource = foos;
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        DetailsView1.DataBind();
    }
    static List<Foo> GetFoos()
    {
        var list = new List<Foo>();
        for(int i=0;i<10;i++)
        {
            list.Add(new Foo {City = "City" + i, Name = "Name" + i});
        }
        return list;
    }
    class Foo
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

public List&lt;Employee> Employees 
{ 
    get { return (List&lt;Employee>)GridView1.DataSource; }
    set // The Presenter calls this
    {
        GridView1.DataSource = value;
        GridView1.DataBind();
    }
}

    //Create a new method for databind
    void BindData()
    {
        IEnumerable<MyDocument> docs = getDocuments();
        myDocsList.DataSource = docs;
        myDocsList.DataBind();
    }
    //Call databind method in your prerender event
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    //Again bind data after delete operation
    protected void myDocsList_ItemCommand(object sender,
           ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int docId = int.Parse(e.CommandArgument.ToString());
            deleteDocument(docId);
            BindData();
        }
    }

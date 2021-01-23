     protected void onSorting_Gridview1(object sender, GridViewSortEventArgs e)
                {
                    string _sortDirection = dir.ToString();
                    if(_sortDirection.Equals("Ascending"))
                    {
                    _sortDirection = "ASC";
                    dir = SortDirection.Descending;
    
                }
                else
                {
                    _sortDirection="DESC";
                    dir = SortDirection.Ascending;
    
                }
               
                if (dt != null)
                {
                    //Sort the data.
                    dt.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                    gridView1.DataSource = dt;
                    gridView1.DataBind();
                }
    
            }
           
     public SortDirection dir
        {
            get
            {
                if (ViewState["DIR"] == null)
                {
                   ViewState["DIR"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["DIR"];
            }
            set
            {
               ViewState["DIR"] = value;
            }
        }

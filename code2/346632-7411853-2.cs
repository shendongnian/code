        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
        }
        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // get date item
                MyDataType item = (MyDataType)e.Row.DataItem;
                // Set value in the necessary cell. You need to specify correct cell index.
                e.Row.Cells[1].Text = item.Property == 0 ? "No" : "Yes"; ;
            }
        }

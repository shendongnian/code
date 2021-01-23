        protected void gvReg_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView gridView = (GridView)sender;
        
            if (e.SortExpression.Length > 0)
            {
                foreach (DataControlField field in gridView.Columns)
                {
                    if (field.SortExpression == e.SortExpression)
                    {
                        cellIndex = gridView.Columns.IndexOf(field);
                        break;
                    }
                }
        
                if (pSortExpression != e.SortExpression)
                {
                    pSortDirection = SortDirection.Ascending;
                }
                else
                {
                    pSortDirection = (pSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
                }
                pSortExpression = e.SortExpression;
            }
        
            //Retrieve the table from the database 
            pSortOrder = pSortDirection == SortDirection.Ascending ? "ASC" : "DESC";
            List<Partners> partnerList = GetPartnerList();
        
            gvReg.DataSource = partnerList;
            gvReg.DataBind();
        
        }

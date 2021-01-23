      protected void Page_Load(object sender, EventArgs e)
        {  
             fillgrid(false, string.Empty, false); //
        }
      
      public void fillgrid(bool sorting, string sortexpression, bool sortdir)
        {
              //binding codes 
               var data = from item in DBcontent.Tablename 
                          select new
                          {
                              Title = item.Title
                          }  
                 if (sorting)
                        {
                            if (sortexpression == "Title")
                            {
                                if (sortdir)
                                {
                                    GrieviewID.DataSource = data.OrderBy(id => id.Title).ToList();
                                }
                                else
                                {
                                    GrieviewID.DataSource = data.OrderByDescending(id => id.Title).ToList();
                                }
                            }
                       else
                        {
                            GrdID.DataSource = data.OrderByDescending(id => id.StartDate).ToList();
                        }
                    GrdID.DataBind();
        }
      protected void grdevents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdevents.PageIndex = e.NewPageIndex;
            BindAndSortGrid();
        }
        /// <summary>
        /// Gets the sort direction.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";
            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }
        /// <summary>
        /// Bind and sort grid.
        /// </summary>
        private void BindAndSortGrid()
        {
            bool sortdir;
            if (ViewState["SortDirection"] != null && ViewState["SortExpression"] != null)
            {
                sortdir = ViewState["SortDirection"].ToString() == "ASC" ? true : false;
                fillgrid(true, ViewState["SortExpression"].ToString(), sortdir);
            }
            else
                fillgrid(false, string.Empty, false);
        }
        protected void grdevents_Sorting(object sender, GridViewSortEventArgs e)
        {
            bool sortdir = GetSortDirection(e.SortExpression) == "ASC" ? true : false;
            fillgrid(true, e.SortExpression.ToString(), sortdir);
        }

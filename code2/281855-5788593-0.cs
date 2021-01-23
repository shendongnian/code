    Yes I think using PagedDataSource is a better option. I'm using it. 
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt_main.DefaultView;
                pds.AllowPaging = true;
                pds.PageSize = 8;
    
                int currentPage;
    
                if (Request.QueryString["page"] != null)
                {
                    currentPage = Int32.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 1;
                }
    
                pds.CurrentPageIndex = currentPage - 1;
                Label1.Text = "Page " + currentPage + " of " + pds.PageCount;
    
                if (!pds.IsFirstPage)
                {
                    linkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + (currentPage - 1);
                }
    
                if (!pds.IsLastPage)
                {
                    linkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + (currentPage + 1);
                }
                gridMain.DataSource = pds;
                gridMain.DataBind();

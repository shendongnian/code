    PagedDataSource = new PagedDataSource();
    PagedDataSource.DataSource = _myData;
    PagedDataSource.AllowPaging = true;
    PagedDataSource.PageSize = 20;
    PagedDataSource.CurrentPageIndex = PageNumber;
    
    if (PagedDataSource.PageCount > 1)
    {
        rptDataPager.Visible = true;
        rptDataPager.DataSource = GetPageRange(10); // try with 4 as you requested
        rptDataPager.DataBind();
    }
    else
        rptDataPager.Visible = false;
    yourRepeater.DataSource = PagedDataSource;
    yourRepeater.DataBind();
    
    // and then the method
    private ArrayList GetPageRange(int pagesToDisplay)
    {
        ArrayList pages = new ArrayList();
        if (PagedDataSource.PageCount <= pagesToDisplay)
        {
            for (int i = 0; i < PagedDataSource.PageCount; i++)
                pages.Add((i + 1).ToString());
        }
        else
        {
            if (PagedDataSource.CurrentPageIndex - (pagesToDisplay / 2) <= 0)
            {
                for (int i = 0; i < pagesToDisplay; i++)
                    pages.Add((i + 1).ToString());
            }
            else if (PagedDataSource.CurrentPageIndex + (pagesToDisplay / 2) >= PagedDataSource.PageCount)
            {
                for (int i = PagedDataSource.PageCount - pagesToDisplay; i < PagedDataSource.PageCount; i++)
                    pages.Add((i + 1).ToString());
            }
            else
            {
                for (int i = PagedDataSource.CurrentPageIndex - (pagesToDisplay / 2); i < PagedDataSource.CurrentPageIndex + (pagesToDisplay / 2); i++)
                    pages.Add((i + 1).ToString());
            }
        }
        return pages;
    }

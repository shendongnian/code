        {
            if (PreviousPage == null)
            {
                TextBox tbSearch = (TextBox)Master.FindControl("txtSearch");
                searchValue.Value = tbSearch.Text;
            }
            else
            {
                TextBox tbSearch = (TextBox)PreviousPage.Master.FindControl("txtSearch");
                searchValue.Value = tbSearch.Text;             
            }
        }

    public void BindGrid(string sortBy, bool inAsc)
        {
            grd.DataSource = WManager.GetAdminTags(txtSearch.Text.Trim(), sortBy, inAsc);
            grd.DataBind();
        }

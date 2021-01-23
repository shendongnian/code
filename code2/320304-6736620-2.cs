            // gets the items table using stored proc GetItem
            gvBlockUnblock.DataSource = AddCommentBLL.GetItem();
            gvBlockUnblock.DataBind();
            // used for paging
            Session["MyDataSett"] = gvBlockUnblock.DataSource;
        }`

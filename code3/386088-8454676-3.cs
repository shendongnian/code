    /// <summary>
            /// bind dropdown with rank in grid
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void GridViewRankChanges_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                DropDownList drdList;
                // Nested DropDownList Control reference is passed to the DrdList object. This will allow you access the properties of dropdownlist placed inside the GridView Template column.
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //bind dropdown rank
                    drdList = (DropDownList)e.Row.FindControl("DropDownListRank");
                    drdList.DataSource = RankList.GetRankList(false);
                    drdList.DataTextField = "Rank";
                    drdList.DataValueField = "RankID";
                    drdList.DataBind();
                    drdList.Items.Insert(0, new ListItem("Select", "0"));
    
                }
            }

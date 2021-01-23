       if (gvMileStone.Rows.Count > 0)
        {
            int index = gvMileStone.SelectedIndex;
            if (index != 0)
            {
                DataTable dtUp = (DataTable)ViewState["Template"];
                int value = Convert.ToInt32(dtUp.Rows[index]["SeqNbr"].ToString());
                dtUp.Rows[index]["SeqNbr"] = value - 1;
                dtUp.Rows[index - 1]["SeqNbr"] = value;
                dtUp.DefaultView.Sort = "SeqNbr";                   
                dtUp.AcceptChanges();
                gvMileStone.DataSource = dtUp;
                gvMileStone.DataBind();
                ViewState["Template"] = dtUp;
            }
        }

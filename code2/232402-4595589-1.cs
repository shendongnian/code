     protected void gvSticker_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
            {
                if (Session["FisherId"] != null)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        Label lblStatus = (Label)e.Row.FindControl("lblStickerStatus");
                     
                        
                        if (e.Row.RowIndex == 0)
                        {
                            if (lblStatus.Text.Contains("Active"))
                            {
                                btnAddSticker.Enabled = false;
                                HyperLink hlStickerNum = (HyperLink)e.Row.FindControl("hlStickerNumber");
                                if (!string.IsNullOrEmpty(hlStickerNum.Text.Trim()))
                                {
                                   

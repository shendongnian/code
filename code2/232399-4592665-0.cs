    protected void OutputGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            outputGridView.EditIndex = e.NewEditIndex;
            GridViewRow row = outputGridView.Rows[outputGridView.EditIndex];
    
            string url = "http://localhost/MyPage.aspx";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type='text/javascript'>");
            sb.AppendLine("window.open('" + url + "')");
            sb.AppendLine("<" + "/script>");
            ClientScript.RegisterStartupScript(this.GetType(), "myjs", sb.ToString(), false);
            //or if the gridview is inside an updatepanel do the code given below
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "myjs", sb.ToString(), false);
        }
        catch (System.Threading.ThreadAbortException)
        {
            throw;
        }
        catch (Exception err)
        {
            //handle error here
            //Elmah.ErrorSignal.FromCurrentContext().Raise(err);
        }        
    }

    protected void btnSaveCase_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            string url = String.Format("{0}/Content/CaseProps.aspx?CaseId={1}",
                ConfigurationManager.AppSettings["website B"],
                geturl(CaseId.ToString()));
            Response.Redirect(url);
        }
        catch (System.Threading.ThreadAbortException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

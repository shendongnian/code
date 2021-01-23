    protected void btnSaveCase_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            string features = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes";
            string name = "mywindow";
            string url = String.Format("{0}/Content/CaseProps.aspx?CaseId={1}",
                ConfigurationManager.AppSettings["website B"],
                geturl(CaseId.ToString()));
            string script = String.Format(@"window.open('{0}','{1}','{2}');",
                url,
                name,
                features);
            ClientScript.RegisterStartupScript(typeof(Page), "key", script, true);
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

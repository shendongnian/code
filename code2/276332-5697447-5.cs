    private void btnSubmit_Click(Object sender, System.EventArgs e)
    {
        foreach (string key in Request.Form.AllKeys)
        {
            Response.Write (string.Format("{0} => {1}<br />", key, request.Form[key]));
        }
    }

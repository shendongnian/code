    static class Extensions
    {
        public static void ShowAlert(this Control control, string message)
        {
            if (!control.Page.ClientScript.IsClientScriptBlockRegistered("PopupScript"))
            {
                var script = String.Format("<script type='text/javascript' language='javascript'>alert('{0}')</script>", message);
                control.Page.ClientScript.RegisterClientScriptBlock(control.Page.GetType(), "PopupScript", script);
            }
            else
            {
                throw new InvalidOperationException("JavaScript/Alert is blocked");
            }
        }
    }

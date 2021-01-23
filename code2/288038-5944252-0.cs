        var page = new FormlessPage();
        var ctrl = (UserControl)page.LoadControl("~/EmailTemplates/OrderConfirmation.ascx");
        page.Controls.Add(ctl);
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.Execute(page, writer, false);
        return writer.ToString();

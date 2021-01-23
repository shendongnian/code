        if (gvDetail.Rows.Count > 0)
        {
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            gvDetail.RenderControl(htmlWrite1);
            gvDetail.AllowPaging = false;
            Search();
            sh.ExportToExcel(gvDetail, "Report");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

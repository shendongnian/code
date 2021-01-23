        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        var page = new NoRenderPage();
        page.DesignerInitialize();
        var form = new HtmlForm();
        page.Controls.Add(form);
        form.Controls.Add(pnl);
        controlToRender.RenderControl(hw);

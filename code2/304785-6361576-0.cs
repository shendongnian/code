    public string RenderRad()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            MyPage p = new MyPage();
            p.DesignerInitialize();
            HtmlForm f = new HtmlForm();
            p.Controls.Add(f);
            f.Controls.Add(re);
            re.RenderControl(hw);
            return sb.ToString();
        }

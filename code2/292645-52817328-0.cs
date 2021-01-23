    /// <summary>
    /// Render Control to HTML as string
    /// </summary>
    public static string Render(this System.Web.UI.Control control)
    {
        var sb = new StringBuilder();
        System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
        System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
        control.RenderControl(htmlWriter);
        return sb.ToString();
    }

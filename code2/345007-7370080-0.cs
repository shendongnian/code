     protected override void Render(System.Web.UI.HtmlTextWriter writer)
     {
      System.IO.StringWriter stringWriter = new System.IO.StringWriter();
      HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
      base.Render(htmlWriter);
      string html = stringWriter.ToString();
      int startPoint = -1;
      int endPoint = -1;
      startPoint = html.IndexOf("<input type=\"hidden\" name=\"__VIEWSTATE\"");
      if (startPoint >= 0)
      {
        endPoint = html.IndexOf("/>", startPoint) + 2;
        string viewstateInput = html.Substring(startPoint, endPoint - startPoint);
        html = html.Remove(startPoint, endPoint - startPoint);
        int FormEndStart = html.IndexOf("</form>") - 1;
        if (FormEndStart >= 0)
          html = html.Insert(FormEndStart + 1, viewstateInput);        
      }
    }

      public string RenderControl()
            {
                StringBuilder stringBuilder = new StringBuilder();
                StringWriter stringWriter = new StringWriter(stringBuilder);
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                RenderControl(htmlTextWriter);
    
                return stringBuilder.ToString();
            }

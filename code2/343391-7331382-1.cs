        StringBuilder sb = new StringBuilder();
        using (StringWriter stringWriter = new StringWriter(sb))
        {
            using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
              Control control= new YourControlWithTextBox();
              WebControlHelper.RenderControl(control, htmlTextWriter);
              return stringWriter.ToString();
            }
        }

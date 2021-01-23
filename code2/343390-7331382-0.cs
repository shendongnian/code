       public static void RenderControl(Control control, HtmlTextWriter response)
            {
                var sWriter = new StringWriter();
                var htmlWriter = new HtmlTextWriter(sWriter);
                
                control.RenderControl(htmlWriter);
    
                // Write HTML
                response.WriteLine(sWriter);
                response.Flush();
            }

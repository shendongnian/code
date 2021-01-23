        private static string RenderControl<T>(T c) where T : Control, new()
        {
            // get the text for the control
            using (StringWriter sw = new StringWriter())
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                c.RenderControl(htw);
                return sw.ToString();
            }
        }

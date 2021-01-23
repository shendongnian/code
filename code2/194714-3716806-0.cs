        private static string GetInlineResult(Action inline)
        {
            // create writers etc.
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htmltw = new HtmlTextWriter(sw);
            object view = inline.Target;
            FieldInfo field = view.GetType().GetField("__w");
            HtmlTextWriter tw = field.GetValue(view) as HtmlTextWriter;
            field.SetValue(view, htmltw);
            // execute 
            inline();
            field.SetValue(view, tw);
            // get contents
            return sb.ToString();
        }

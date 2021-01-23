        public static MvcHtmlString AddScript(this HtmlHelper htmlHelper, string script, int executionSequence = int.MaxValue)
        {
            Dictionary<int, List<string>> scripts = new Dictionary<int, List<string>>();
            if (htmlHelper.ViewContext.HttpContext.Items["_scripts_"] != null)
            {
                scripts = htmlHelper.ViewContext.HttpContext.Items["_scripts_"] as Dictionary<int, List<string>>;
            }
            if (!scripts.ContainsKey(executionSequence))
            {
                scripts.Add(executionSequence, new List<string>());
            }
            string tag = string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", script);
            scripts[executionSequence].Add(tag);
            htmlHelper.ViewContext.HttpContext.Items["_scripts_"] = scripts;
            return MvcHtmlString.Empty;
        }

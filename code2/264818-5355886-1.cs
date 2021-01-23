    public static class HtmlHelpers
    {
        public static MvcHtmlString Markdown(this HtmlHelper helper, string text)
        {
            var markdown = new MarkdownSharp.Markdown
            {
                AutoHyperlink = true,
                EncodeCodeBlocks = false, // This option is my custom option to stop the code block encoding problem.
                LinkEmails = true,
                EncodeProblemUrlCharacters = true
            };
            string html = markdown.Transform(markdownText);
            return MvcHtmlString.Create(html);
        }
    }

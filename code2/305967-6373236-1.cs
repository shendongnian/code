    public MvcHtmlString GenerateLink(bool enabled)
    {
        if (enabled)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergAttribute("src", Url.Action("Video", "Play")); // Pseudo-code
            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
        else
            return "N/A";
    }

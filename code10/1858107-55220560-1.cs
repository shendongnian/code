    [HtmlTargetElement(“website-search”)]
    Public class Search : TagHelper
    {
        Public WebsiteContext Info { get; set; }
        Public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Output.TagName = “section”;
            Output.Content.SetHtmlContent(“ HTML for your search form “);
            Output.TagMode = TagMode.StartTagAndEndTag;
        }
    }

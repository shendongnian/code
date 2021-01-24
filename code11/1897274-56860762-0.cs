    //This is the parent that helper
    [HtmlTargetElement("tabs-nav")]
    public class TabsNavTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
            //Your parent tag helper over logic here
            output.Content.AppendHtml(await output.GetChildContentAsync(false));
        }
    }
    //This is the child that helper
    [HtmlTargetElement("tabs")]
    public class TabTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
            //Your child tag helper over logic here
        }
    }

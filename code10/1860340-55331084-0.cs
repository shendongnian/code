    namespace DemoApp.Helpers
    {
        public class TestTagHelper : TagHelper
        {
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName="div";
                output.Content.Append("Run...");
            }
        }
    }

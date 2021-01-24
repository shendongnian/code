        public class EmailTagHelper: TagHelper
    {
        private const string EmailDomain = "contoso.com";
        // Can be passed via <email mail-to="..." />. 
        // PascalCase gets translated into kebab-case.
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag
            var address = MailTo + "@" + EmailDomain;
          
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
            CreateOrMergeAttribute("class", "test", output);
        }
        private void CreateOrMergeAttribute(string name, object content, TagHelperOutput output)
        {
            var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == name);
            if (currentAttribute == null)
            {
                var attribute = new TagHelperAttribute(name, content);
                output.Attributes.Add(attribute);
            }
            else
            {
                var newAttribute = new TagHelperAttribute(
                    name,
                    $"{currentAttribute.Value.ToString()} {content.ToString()}",
                    currentAttribute.ValueStyle);
                output.Attributes.Remove(currentAttribute);
                output.Attributes.Add(newAttribute);
            }
        }
    }

cs
[HtmlTargetElement("editor", Attributes = "for, html-attributes", TagStructure = TagStructure.WithoutEndTag)]
public class EditorTagHelper : TagHelper {
Then map those to a property on the tag helper itself:
cs
[HtmlAttributeName("html-attributes")]
public Dictionary<string, string> HtmlAttributes { get; set; }
In the process method, deconstruct and foreach through that dictionary
cs
foreach (var (key, value) in HtmlAttributes)
{
    output.Attributes.SetAttribute(key, value);
}
Use it like:
cs
<editor for="Name" view-data-test="@("Foo")" html-attributes="@ViewData["HtmlAttributes"]" />
**Edit:**
If you want to only pass the ViewData to the template and then apply them to the input element inside you'd need to follow the same procedure as I told you. But you skip applying the htmlAttributes to the Editor element.
cs
    [HtmlTargetElement("input", Attributes = "for, html-attributes")]
    public class InputTagHelper : TagHelper
    {
        public ModelExpression For { get; set; }
        [HtmlAttributeName("html-attributes")]
        public Dictionary<string, string> HtmlAttributes { get; set; }
        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagMode = TagMode.SelfClosing;
            output.Attributes.SetAttribute("name", EditorFor.Name);
            foreach (var (key, value) in HtmlAttributes)
            {
                output.Attributes.SetAttribute(key, value);
            }
        }
Then in your template, you can do:
cs
@model string
<input asp-for="@Model" html-attributes="@((IDictionary<string, string>)ViewData["HtmlAttributes"])" />

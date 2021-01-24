cs
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace DL.SO.Framework.Mvc.TagHelpers
{
    public class TestTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int carouselWidth = 300;
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute(
                "style", 
                $"width: { carouselWidth }px; height: { carouselWidth }px; background-color: green;");
            output.Content.SetHtmlContent(div);
        }
    }
}
[![enter image description here][1]][1]
<br>
Because your post is unclear, based on your "code", I think you should set the attribute `class` as well so that your style could be applied.
cs
int carouselWidth = 300;
TagBuilder div = new TagBuilder("div");
div.MergeAttribute(
    "style", 
    $"width: { carouselWidth }px; height: { carouselWidth }px;");
div.MergeAttribute(
    "class", 
    "test");
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/JQeR2.png
  [2]: https://i.stack.imgur.com/PMMKy.png

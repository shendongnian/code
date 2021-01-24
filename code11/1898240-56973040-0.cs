    namespace System.Web.Mvc
    {
        public static partial class HtmlHelperExtensions
        {
    
            public static MvcHtmlString CustomComponent(this HtmlHelper helper, string QuestionTypeId)
            {
                if (QuestionTypeId == "Text")
                {
                    var inputTag = new TagBuilder("input");
                    inputTag.MergeAttribute("type", "text");
                    return MvcHtmlString.Create(inputTag.ToString());
                }
                else if (QuestionTypeId == "DropDown")
                {
                    var dropDownTag = new TagBuilder("select");
                    dropDownTag.MergeAttribute("type", "text");
    
    
                    var option = new TagBuilder("option");
                    option.InnerHtml = "Option 1";
                    option.MergeAttribute("value", "option1");
    
                    dropDownTag.InnerHtml += option.ToString();
    
                    option = new TagBuilder("option");
                    option.InnerHtml = "Option 2";
                    option.MergeAttribute("value", "option2");
    
                    dropDownTag.InnerHtml += option.ToString();
    
                    return MvcHtmlString.Create(dropDownTag.ToString());
                }
                else
                {
                    var inputTag = new TagBuilder("input");
                    inputTag.MergeAttribute("type", "checkbox");
                    return MvcHtmlString.Create(inputTag.ToString());
                }
            }
         }
    }

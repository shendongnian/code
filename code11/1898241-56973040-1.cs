    public static MvcHtmlString CustomComponent(this HtmlHelper helper, QuestionModel questionModel)
            {
                if (questionModel.QuestionTypeId==QuestionTypes.Text)
                {
                    var inputTag = new TagBuilder("input");
                    inputTag.MergeAttribute("type", "text");
                    return MvcHtmlString.Create(inputTag.ToString());
                }
            }

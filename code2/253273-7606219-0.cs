            var meta = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            var input = new TagBuilder("input");
            input.MergeAttribute("id",
                                 helper.AttributeEncode(helper.ViewData.TemplateInfo.GetFullHtmlFieldId(propertyName)));
            input.MergeAttribute("name",
                                 helper.AttributeEncode(
                                     helper.ViewData.TemplateInfo.GetFullHtmlFieldName(propertyName)));
            input.MergeAttribute("value", ((DateTime)meta.Model).ToShortDateString());
            input.MergeAttribute("type", "text");
            input.MergeAttribute("class", "text cal");
            input.MergeAttribute("tabindex", tabIndex.ToString());
            input.MergeAttributes(helper.GetUnobtrusiveValidationAttributes(ExpressionHelper.GetExpressionText(expression), meta));
            return MvcHtmlString.Create(input.ToString());
        }

        public class CustomAttributeTagHelper : TagHelper
        {
            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                output.Content.AppendHtml("<div>");
                string validationAnnotationMessage = string.Empty, validationAnnotationInput = string.Empty;
                UserSchema userSchema = new UserSchema { PropertyName = "Title" , Title = "Title", Type = "string"};
                (validationAnnotationMessage, validationAnnotationInput) = ValidationAnnotation(userSchema);
                if (userSchema.Type == "string")
                {
                    output.Content.AppendHtml("<div>");
                    string value = string.Empty;
                    output.Content.AppendHtml(
                        $"<Label for= {userSchema.PropertyName}> {userSchema.Title} </Label>");
                    output.Content.AppendHtml(
                        $"<Input {validationAnnotationInput} for= '{userSchema.PropertyName}' Id='{userSchema.PropertyName}' name='{userSchema.PropertyName}' value='{value}'/>");
                    output.Content.AppendHtml($"<span   />");
                    output.Content.AppendHtml($"<span {validationAnnotationMessage}  ></span>");
                    output.Content.AppendHtml("</div>");
                }
                output.Content.AppendHtml("</div>");
            }
            private Tuple<string, string> ValidationAnnotation(
            UserSchema userSchema)
            {
                var validationAnnotationMessage =
                    $"data-valmsg-replace=true data-valmsg-for='{userSchema.PropertyName}' class='field-validation-valid'";
                var validationAnnotationInput = $"data-val=true data-val-required='{userSchema.Title} is required'";
                return new Tuple<string, string>(validationAnnotationMessage, validationAnnotationInput);
            }
        }

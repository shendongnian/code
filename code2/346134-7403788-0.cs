    private IHtmlString BuildRadioButton(string name, object value, bool? isChecked, IDictionary<string, object> attributes) {
            string valueString = ConvertTo(value, typeof(string)) as string;
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "radio", true);
            builder.GenerateId(name);
            builder.MergeAttributes(attributes, replaceExisting: true);
            builder.MergeAttribute("value", valueString, replaceExisting: true);
            builder.MergeAttribute("name", name, replaceExisting: true);
            var modelState = ModelState[name];
            string modelValue = null;
            if (modelState != null) {
                modelValue = ConvertTo(modelState.Value, typeof(string)) as string;
                isChecked = isChecked ?? String.Equals(modelValue, valueString, StringComparison.OrdinalIgnoreCase);
            }
            if (isChecked.HasValue) {
                // Overrides attribute values
                if (isChecked.Value) {
                    builder.MergeAttribute("checked", "checked", true);
                }
                else {
                    builder.Attributes.Remove("checked");
                }
            }
            AddErrorClass(builder, name);
            return builder.ToHtmlString(TagRenderMode.SelfClosing);
        }

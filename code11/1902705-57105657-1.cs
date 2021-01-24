    public static class TagBuilderExtensions
    {
        public void AddCssClassEnd(this TagBuilder tagBuilder, string value)
        {
            string currentValue;
            if (tagBuilder.Attributes.TryGetValue("class", out currentValue))
            {
                tagBuilder.Attributes["class"] = currentValue + " " + value;
            }
            else
            {
                tagBuilder.Attributes["class"] = value;
            }
        }
    }
	

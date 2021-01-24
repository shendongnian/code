    [HtmlTargetElement("styled-checkbox")]  
        public class MyCustomTagHelper : TagHelper  
        {  
            public string Name { get; set; }  
            public override void Process(TagHelperContext context, TagHelperOutput output)  
            {  
                output.TagName = "span";  
                output.TagMode = TagMode.StartTagAndEndTag;  
                // collect all attributes of styled-checkbox tag
                var attributes = context.AllAttributes.ToDictionary(a => a.Name, a => a.Value.ToString()); 
                var writer = new System.IO.StringWriter();
                CreateInputTagBuilder(attributes).WriteTo(writer, HtmlEncoder.Default);
                CreateHiddenInputTagBuilder().WriteTo(writer, HtmlEncoder.Default);
                // clear attributes of styled-checkbox
                output.Attributes.Clear();
                output.Content.SetHtmlContent(writer.ToString());
            }  
            private TagBuilder CreateInputTagBuilder(Dictionary<string,string> attributes)
            {
                
                var inputBuilder = new TagBuilder("input");
                inputBuilder.MergeAttributes(attributes);
                // use MergeAttribute instead of Add, Add method throws exception if an attribute exists
                inputBuilder.MergeAttribute("type","checkbox");
                inputBuilder.MergeAttribute("name",this.Name);
                return inputBuilder;
            }
            private TagBuilder CreateHiddenInputTagBuilder()
            {
                var inputBuilder = new TagBuilder("input");
                inputBuilder.Attributes.Add("type","hidden");
                return inputBuilder;
            }
        }

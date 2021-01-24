        [HtmlTargetElement("input",Attributes = "asp-for-prop")]
        public class ConditionTagHelper:TagHelper
        { 
           [HtmlAttributeName("asp-for-prop")]
           public ModelExpression Property { get; set; }
           [HtmlAttributeName("asp-for-model")]
           public ModelExpression Hobby { get; set; }
        
          public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var propName = Property.ModelExplorer.Model.ToString();
            var modelName = Hobby.Name.ToString();
            var modelExProp = Hobby.ModelExplorer.Properties.Single(x=>x.Metadata.PropertyName.Equals(propName));
            var propValue = modelExProp.Model;
            var para = modelName + "." + propName;
          
            output.Attributes.Add("id", para);
            output.Attributes.Add("name", para);
            output.Attributes.Add("value", propValue);
            base.Process(context, output);
            
        }
    }

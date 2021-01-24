    [htmlTargetElement("div")]
    public class DivTagHelper :TagHelpers {
    public override void process(TagHelperContext context, TahHelperOutput output)
     context.Items["myData"]="somethings";
    }
    
    
    [htmlTargetElement("button", ParentTag="div")]
    public class ButtonTagHelper :TagHelpers {
    public override void process(TagHelperContext context, TahHelperOutput output)
     string strName=context.Items["myData"];
    }

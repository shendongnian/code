     //MyControlBuilder 
     public class MyControlBuilder : ControlBuilder
     {
       public override Type GetChildControlType(string tagName, IDictionary attribs)
       { 
         if (tagName.StartsWith("childnode")) return typeof(Control);
         else return base.GetChildControlType(tagName,attribs);
       }
       public override void AppendLiteralString(string s)
       { 
         //ignore literals betwen tags
       }
     }
     //MyCustomControl
     [ParseChildren(false)]
     [ControlBuilder(typeof(MyControlBuilder))]
     public class MyCustomControl : Control
     {
       public string attribute1 {get;set;}
       public string attribute2 {get;set;}
       protected override void AddParsedSubObject(object obj)
       {
         Control ctrl = (Control) obj;
         LiteralControl childNode = ctrl.Controls[0];
         //Add as-is (e.g., literal "value1")
         Controls.Add(childNode);
       }
     }

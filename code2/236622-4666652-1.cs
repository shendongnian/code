    class Node
    {
       public virtual string ToDisplayText(params object[] parameters)
       {
          return string.Empty;
       }
    }
    class TextNode : Node
    {
       public override string ToDisplayText(params object[] parameters)
       {
          return this.Text;
       }
    }
    class VariableNode : Node
    {
       public override string ToDisplayText(params object[] parameters)
       {
          //check parameters
          var dict = (Dictionary<string,string>)parameters[0];
          return dict[this.Name];
       }
    }

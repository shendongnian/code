    class Node
    {
       public virtual string ToDisplayText()
       {
          return string.Empty;
       }
    }
    class TextNode : Node
    {
       public override string ToDisplayText()
       {
          return this.Text;
       }
    }

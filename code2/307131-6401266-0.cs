    public class ParentDetail
    {
       public HtmlText Text {get; set;}
    
       public bool IsEmpty  
       {
          return this.Text == null || String.IsNullOrEmpty(this.Text.TextWithHtml);
       }
    }

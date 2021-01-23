    public UIElement GetControl()  
    {  
      StringBuilder sb = new StringBuilder();    
      sb.Append("<TextBox xmlns='http://schemas.microsoft.com/client/2007'> ");  
      sb.Append(Model.QuestionAttributes.DrawAttributes());  
      sb.Append("/>");  
      TextBox Textbox = XamlReader.Load(sb.ToString()) as TextBox;  
    
      return Textbox as TextBox;       
    }

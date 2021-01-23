    public class SomeSelector : DataTemplateSelector
    {
       public DataTemplate Template1 { get; set; }
       public DataTemplate Template2 { get; set; }
    
       public override DataTemplate SelectTemplate(object item, DependencyObject container)
       {
          if (item is IDictionary<string, int>) 
          {
             return Template1;
          }
    
          return Template2;
       }
    }

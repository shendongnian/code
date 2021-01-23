    using System.Windows;
    using System.Windows.Controls;
    using TemplateSelector.Models;
     
    namespace TemplateSelector.Util
    {
      public class MyTemplateSelector : DataTemplateSelector
      {
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }
        
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
          Person person = item as Person;
          if (person != null) return person.Working ? this.Template1 : this.Template2;
          return null;
        }
      }
    }

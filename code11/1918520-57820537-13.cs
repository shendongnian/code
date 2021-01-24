    class DataTemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
      public override DataTemplate
        SelectTemplate(object item, DependencyObject container)
      {
        FrameworkElement element = container as FrameworkElement;
    
         return item is Session 
           ? element.FindResource("SessionDataTemplate") as DataTemplate 
           : element.FindResource("FolderDataTemplate") as DataTemplate;
      }
    }

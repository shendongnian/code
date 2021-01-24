    class DataTemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
      public override DataTemplate
        SelectTemplate(object item, DependencyObject container)
      {
        FrameworkElement element = container as FrameworkElement;
    
         return item is FirstViewModel 
           ? element.FindResource("FirstDataTemplate") as DataTemplate 
           : item is SecondViewModel 
             ? element.FindResource("SecondDataTemplate") as DataTemplate
             : item is ThirdViewModel 
               ? element.FindResource("ThirdDataTemplate") as DataTemplate
               : item is IndFeatureViewModel
                 ? element.FindResource("IndFeatureDataTemplate") as DataTemplate
                 : element.FindResource("IndUsecaseDataTemplate") as DataTemplate;
      }
    }

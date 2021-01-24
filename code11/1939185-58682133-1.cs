    class PageTemplateSelector : DataTemplateSelector
    {
      #region Overrides of DataTemplateSelector
    
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
        var element = container as FrameworkElement;
        switch (item)
        {
          case PageA _: return element.FindResource("PageADataTemplate") as DataTemplate;
          case PageB _: return element.FindResource("PageBDataTemplate") as DataTemplate;
        }
        return base.SelectTemplate(item, container);
      }
    
      #endregion
    }

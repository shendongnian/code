    ListBoxItem item = (ListBoxItem)(this.lst.ItemContainerGenerator.ContainerFromIndex(i));
    ContentPresenter presenter = FindVisualChild<ContentPresenter>(item);
    DataTemplate template = presenter.ContentTemplate;
    StackPanel stack = (StackPanel)template.FindName("FirstColumn Panel Name", presenter);
  

     public class ListBoxItemTemplateSelector:DataTemplateSelector
        {
           public DataTemplate NonHighlightedItemTemplate { get; set; }
           public DataTemplate HighlightedItemTemplate { get; set; }
           public ListBox ParentListBox { get; set; }
    
    
    
             public override DataTemplate SelectTemplate(object item, DependencyObject container)
           {
                 var listBoxItem = ((FrameworkElement) container).TemplatedParent as ListBoxItem;
                 var panel = VisualTreeHelper.GetParent(listBoxItem) as Panel;
                 var highlightedIndex = (panel.DataContext as DataItems).HighlightedIndex;
                 var currentChildIndex = panel.Children.Count-1;
    
                 return (highlightedIndex == currentChildIndex) ? HighlightedItemTemplate : NonHighlightedItemTemplate;
                }
        }
    }

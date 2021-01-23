    public class ListBoxSelectionItemChangedOnMouseUp : ListBox
    {
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DependencyObject obj = this.ContainerFromElement((Visual)e.OriginalSource);
                if (obj != null)
                {
                    FrameworkElement element = obj as FrameworkElement;
                    if (element != null)
                    {
                        ListBoxItem item = element as ListBoxItem;
                        if (item != null && this.Items.Contains(item))
                        {
                            this.SelectedItem = item;
                        }
                    }
                }
            }
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }

    public class MyItemsControl : System.Windows.Controls.ItemsControl
    {
        protected virtual DependencyObject GetContainerForItemOverride()
        {
            return new MyUserControl();
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is MyUserControl);
        }
    }

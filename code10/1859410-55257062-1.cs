    public class MyContainer : ContentControl
    {
    }
    public class MyItemsControl : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyContainer();
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is MyContainer;
        }
    }

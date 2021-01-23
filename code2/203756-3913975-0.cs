     public class SeparatorTabStyleSelector : StyleSelector
    {
        #region " StyleSelector Implementation "
        public override Style SelectStyle(
            object item,
            DependencyObject container)
        {
            object data = item as 'Your Bindable Object';
            if ('Your Condition Based upon item object')
            {
                return (Style)((FrameworkElement)container).FindResource("Style1");
            }
            else if ('If Condition is not true Based upon item object')
            {
                return (Style)((FrameworkElement)container).FindResource("Style2");
            }
            return base.SelectStyle(item, container);
        }
        #endregion " StyleSelector Implementation "
    }

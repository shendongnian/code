    public class PageChangedBehavior
    {
        #region Attached property
        public static ICommand PageChangedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(PageChangedCommandProperty);
        }
        public static void SetPageChangedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(PageChangedCommandProperty, value);
        }
        public static readonly DependencyProperty PageChangedCommandProperty =
            DependencyProperty.RegisterAttached("PageChangedCommand", typeof(ICommand), typeof(PageChangedBehavior),
                new PropertyMetadata(null, OnPageChanged));
        #endregion
        #region Attached property handler
        private static void OnPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PageControl;
            if (control != null)
            {
                if (e.NewValue != null)
                {
                    control.PageChanged += PageControl_PageChanged;
                }
                else
                {
                    control.PageChanged -= PageControl_PageChanged;
                }
            }
        }
        static void PageControl_PageChanged(object sender, int page)
        {
            ICommand command = PageChangedCommand(sender as DependencyObject);
            if (command != null)
            {
                command.Execute(page);
            }
        }
        #endregion

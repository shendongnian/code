    public static class Extensions
    {
        public static T SetDock<T>(this T element, Dock dock) where T : UIElement
        {
            DockPanel.SetDock(element, dock);
            return element;
        }
        public static T SetColumn<T>(this T element, int value) where T : UIElement
        {
            Grid.SetColumn(element, value);
            return element;
        }
        public static T SetValue_<T>(this T factory, DependencyProperty dp, object value) where T : FrameworkElementFactory
        {
            factory.SetValue(dp, value);
            return factory;
        }
        public static T AppendChildren<T>(this T factory, params FrameworkElementFactory[] children) where T : FrameworkElementFactory
        {
            foreach (var child in children)
                factory.AppendChild(child);
            return factory;
        }
        public static T SetVisualTree<T>(this T template, FrameworkElementFactory factory) where T : FrameworkTemplate
        {
            template.VisualTree = factory;
            return template;
        }
        public static T1 SetItemsPanel<T1,T2>(this T1 control, T2 template) where T1 : ItemsControl where T2 : ItemsPanelTemplate
        {
            control.ItemsPanel = template;
            return control;
        }
        public static T AddItems<T>(this T control, params object[] items) where T : ItemsControl
        {
            foreach (var item in items)
                control.Items.Add(item);
            return control;
        }
        public static T AddSelectionChanged<T>(this T obj, RoutedEventHandler handler) where T : TextBoxBase
        {
            obj.SelectionChanged += handler;
            return obj;
        }
        public static T1 AddChildren<T1>(this T1 panel, params UIElement[] elements) where T1 : Panel
        {
            foreach (var elt in elements)
                panel.Children.Add(elt);
            return panel;
        }
    }

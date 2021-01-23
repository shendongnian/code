    [ContentProperty("Content")]
    public class ModalContentPresenter : FrameworkElement
    {
        private Panel layoutRoot;
        private ContentPresenter primaryContent;
        private ContentPresenter modalContent;
        private Border overlay;
        private VisualCollection visualChildren;
        private object[] logicalChildren;
        private KeyboardNavigationMode cachedKeyboardNavigationMode;
        private static readonly TraversalRequest traversalDirection;
        public static readonly DependencyProperty IsModalProperty =
            DependencyProperty.Register("IsModal", 
                typeof(bool), 
                typeof(ModalContentPresenter),
                new FrameworkPropertyMetadata(false, 
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnIsModalChanged));
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", 
                typeof(object), 
                typeof(ModalContentPresenter),
                new UIPropertyMetadata(null, OnContentChanged));
        public static readonly DependencyProperty ModalContentProperty =
            DependencyProperty.Register("ModalContent", 
            typeof(object), 
            typeof(ModalContentPresenter),
            new UIPropertyMetadata(null, OnModalContentChanged));
        public static readonly DependencyProperty OverlayBrushProperty = 
            DependencyProperty.Register("OverlayBrush", 
            typeof(Brush), 
            typeof(ModalContentPresenter),
            new UIPropertyMetadata(new SolidColorBrush(
                Color.FromArgb(204,169,169,169))));
        public bool IsModal
        {
            get { return (bool)GetValue(IsModalProperty); }
            set { SetValue(IsModalProperty, value); }
        }
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public object ModalContent
        {
            get { return (object)GetValue(ModalContentProperty); }
            set { SetValue(ModalContentProperty, value); }
        }
        public Brush OverlayBrush
        {
            get { return (Brush)GetValue(OverlayBrushProperty); }
            set { SetValue(OverlayBrushProperty, value); }
        }
        public static readonly RoutedEvent PreviewModalContentShownEvent =
            EventManager.RegisterRoutedEvent("PreviewModalContentShown",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventArgs),
            typeof(ModalContentPresenter));
        public static readonly RoutedEvent ModalContentShownEvent =
            EventManager.RegisterRoutedEvent("ModalContentShown",
            RoutingStrategy.Bubble, 
            typeof(RoutedEventArgs), 
            typeof(ModalContentPresenter));
        public static readonly RoutedEvent PreviewModalContentHiddenEvent =
            EventManager.RegisterRoutedEvent("PreviewModalContentHidden",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventArgs),
            typeof(ModalContentPresenter));
        public static readonly RoutedEvent ModalContentHiddenEvent =
            EventManager.RegisterRoutedEvent("ModalContentHidden",
            RoutingStrategy.Bubble,
            typeof(RoutedEventArgs),
            typeof(ModalContentPresenter));
        public event RoutedEventHandler PreviewModalContentShown
        {
            add { AddHandler(PreviewModalContentShownEvent, value); }
            remove { RemoveHandler(PreviewModalContentShownEvent, value); }
        }
        public event RoutedEventHandler ModalContentShown
        {
            add { AddHandler(ModalContentShownEvent, value); }
            remove { RemoveHandler(ModalContentShownEvent, value); }
        }
        public event RoutedEventHandler PreviewModalContentHidden
        {
            add { AddHandler(PreviewModalContentHiddenEvent, value); }
            remove { RemoveHandler(PreviewModalContentHiddenEvent, value); }
        }
        public event RoutedEventHandler ModalContentHidden
        {
            add { AddHandler(ModalContentHiddenEvent, value); }
            remove { RemoveHandler(ModalContentHiddenEvent, value); }
        }
        static ModalContentPresenter()
        {
            traversalDirection = 
                new TraversalRequest(FocusNavigationDirection.First);
        }
        public ModalContentPresenter()
        {
            layoutRoot = new Grid();
            primaryContent = new ContentPresenter();
            modalContent = new ContentPresenter();
            overlay = new Border();
            visualChildren = new VisualCollection(this);
            visualChildren.Add(layoutRoot);
            logicalChildren = new object[2];
            overlay.Background = OverlayBrush;
            overlay.Child = modalContent;
            overlay.Visibility = Visibility.Hidden;
            layoutRoot.Children.Add(primaryContent);
            layoutRoot.Children.Add(overlay);
        }
        public void ShowModalContent()
        {
            if(!IsModal) 
                IsModal= true;
        }
        public void HideModalContent()
        {
            if (IsModal)
                IsModal = false;
        }
        private void RaiseModalContentShownEvents()
        {
            RoutedEventArgs args = new RoutedEventArgs(PreviewModalContentShownEvent);
            OnPreviewModalContentShown(args);
            if (!args.Handled)
            {
                args = new RoutedEventArgs(ModalContentShownEvent);
                OnModalContentShown(args);
            }
        }
        private void RaiseModalContentHiddenEvents()
        {
            RoutedEventArgs args = new RoutedEventArgs(PreviewModalContentHiddenEvent);
            OnPreviewModalContentHidden(args);
            if (!args.Handled)
            {
                args = new RoutedEventArgs(ModalContentHiddenEvent);
                OnModalContentHidden(args);
            }
        }
        protected virtual void OnPreviewModalContentShown(RoutedEventArgs e)
        {
            RaiseEvent(e);
        }
        protected virtual void OnModalContentShown(RoutedEventArgs e)
        {
            RaiseEvent(e);
        }
        protected virtual void OnPreviewModalContentHidden(RoutedEventArgs e)
        {
            RaiseEvent(e);
        }
        protected virtual void OnModalContentHidden(RoutedEventArgs e)
        {
            RaiseEvent(e);
        }
        private static void OnIsModalChanged(DependencyObject d, 
                                             DependencyPropertyChangedEventArgs e)
        {
            ModalContentPresenter control = (ModalContentPresenter)d;
            if ((bool)e.NewValue == true)
            {
                control.cachedKeyboardNavigationMode = 
                    KeyboardNavigation.GetTabNavigation(control.primaryContent);
                KeyboardNavigation.SetTabNavigation(
                    control.primaryContent, KeyboardNavigationMode.None);
                control.overlay.Visibility = Visibility.Visible;
                control.overlay.MoveFocus(traversalDirection);
                control.RaiseModalContentShownEvents();
            }
            else
            {
                control.overlay.Visibility = Visibility.Hidden;
                KeyboardNavigation.SetTabNavigation(
                    control.primaryContent, control.cachedKeyboardNavigationMode);
                control.primaryContent.MoveFocus(traversalDirection);
                control.RaiseModalContentHiddenEvents();
            }
        }
        private static void OnContentChanged(DependencyObject d, 
                                             DependencyPropertyChangedEventArgs e)
        {
            ModalContentPresenter control = (ModalContentPresenter)d;
            if (e.OldValue != null)
            {
                control.RemoveLogicalChild(e.OldValue);
            }
            control.primaryContent.Content = e.NewValue;
            control.AddLogicalChild(e.NewValue);
            control.logicalChildren[0] = e.NewValue;
        }
        private static void OnModalContentChanged(DependencyObject d, 
                                                  DependencyPropertyChangedEventArgs e)
        {
            ModalContentPresenter control = (ModalContentPresenter)d;
            if (e.OldValue != null)
            {
                control.RemoveLogicalChild(e.OldValue);
            }
            control.modalContent.Content = e.NewValue;
            control.AddLogicalChild(e.NewValue);
            control.logicalChildren[1] = e.NewValue;
        }
        private static void OnOverlayBrushChanged(DependencyObject d, 
                                                  DependencyPropertyChangedEventArgs e)
        {
            ModalContentPresenter control = (ModalContentPresenter)d;
            control.overlay.Background = (Brush)e.NewValue;
        }
        protected override System.Windows.Media.Visual GetVisualChild(int index)
        {
            return visualChildren[index];
        }
        protected override int VisualChildrenCount 
        { 
            get { return visualChildren.Count; } 
        }
        protected override System.Collections.IEnumerator LogicalChildren
        {
            get { return logicalChildren.GetEnumerator(); }
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            layoutRoot.Arrange(new Rect(finalSize));
            return finalSize;
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            layoutRoot.Measure(availableSize);
            return layoutRoot.DesiredSize;
        }
    }

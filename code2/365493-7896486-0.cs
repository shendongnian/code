    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using Kent.Boogaart.HelperTrinity.Extensions;
    public static class DragDrop
    {
        public static readonly RoutedEvent PreviewBeginDragEvent = EventManager.RegisterRoutedEvent(
            "PreviewBeginDrag",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(DragDrop));
        public static readonly RoutedEvent BeginDragEvent = EventManager.RegisterRoutedEvent(
            "BeginDrag",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(DragDrop));
        public static readonly RoutedEvent PreviewDragEvent = EventManager.RegisterRoutedEvent(
            "PreviewDrag",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(DragDrop));
        public static readonly RoutedEvent DragEvent = EventManager.RegisterRoutedEvent(
            "Drag",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(DragDrop));
        public static readonly RoutedEvent PreviewEndDragEvent = EventManager.RegisterRoutedEvent(
            "PreviewEndDrag",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(DragDrop));
        public static readonly RoutedEvent EndDragEvent = EventManager.RegisterRoutedEvent(
            "EndDrag",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(DragDrop));
        public static readonly DependencyProperty CanDragProperty = DependencyProperty.RegisterAttached(
            "CanDrag",
            typeof(bool),
            typeof(DragDrop),
            new FrameworkPropertyMetadata(OnCanDragChanged));
        public static readonly DependencyProperty IsDragInProgressProperty;
        public static readonly DependencyProperty DragParentProperty = DependencyProperty.RegisterAttached(
            "DragParent",
            typeof(FrameworkElement),
            typeof(DragDrop));
        public static readonly DependencyProperty XOffsetProperty = DependencyProperty.RegisterAttached(
            "XOffset",
            typeof(double),
            typeof(DragDrop));
        public static readonly DependencyProperty YOffsetProperty = DependencyProperty.RegisterAttached(
            "YOffset",
            typeof(double),
            typeof(DragDrop));
        private static readonly DependencyPropertyKey isDragInProgressPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "IsDragInProgress",
            typeof(bool),
            typeof(DragDrop),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        private static readonly DependencyProperty DragPointProperty = DependencyProperty.RegisterAttached(
            "DragPoint",
            typeof(Point?),
            typeof(DragDrop),
            new PropertyMetadata());
        static DragDrop()
        {
            IsDragInProgressProperty = isDragInProgressPropertyKey.DependencyProperty;
        }
        public static void AddPreviewBeginDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.AddHandler(PreviewBeginDragEvent, handler);
            }
        }
        public static void RemovePreviewBeginDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.RemoveHandler(PreviewBeginDragEvent, handler);
            }
        }
        public static void AddBeginDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.AddHandler(BeginDragEvent, handler);
            }
        }
        public static void RemoveBeginDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.RemoveHandler(BeginDragEvent, handler);
            }
        }
        public static void AddPreviewDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.AddHandler(PreviewDragEvent, handler);
            }
        }
        public static void RemovePreviewDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.RemoveHandler(PreviewDragEvent, handler);
            }
        }
        public static void AddDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.AddHandler(DragEvent, handler);
            }
        }
        public static void RemoveDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.RemoveHandler(DragEvent, handler);
            }
        }
        public static void AddPreviewEndDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.AddHandler(PreviewEndDragEvent, handler);
            }
        }
        public static void RemovePreviewEndDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.RemoveHandler(PreviewEndDragEvent, handler);
            }
        }
        public static void AddEndDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.AddHandler(EndDragEvent, handler);
            }
        }
        public static void RemoveEndDragHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            var inputElement = dependencyObject as IInputElement;
            if (inputElement != null)
            {
                inputElement.RemoveHandler(EndDragEvent, handler);
            }
        }
        public static bool GetCanDrag(FrameworkElement frameworkElement)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            return (bool)frameworkElement.GetValue(CanDragProperty);
        }
        public static void SetCanDrag(FrameworkElement frameworkElement, bool canDrag)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            frameworkElement.SetValue(CanDragProperty, canDrag);
        }
        public static FrameworkElement GetDragParent(DependencyObject dependencyObject)
        {
            dependencyObject.AssertNotNull("dependencyObject");
            return dependencyObject.GetValue(DragParentProperty) as FrameworkElement;
        }
        public static void SetDragParent(DependencyObject dependencyObject, FrameworkElement dragParent)
        {
            dependencyObject.AssertNotNull("dependencyObject");
            dependencyObject.SetValue(DragParentProperty, dragParent);
        }
        public static double GetXOffset(FrameworkElement frameworkElement)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            return (double)frameworkElement.GetValue(XOffsetProperty);
        }
        public static void SetXOffset(FrameworkElement frameworkElement, double xOffset)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            frameworkElement.SetValue(XOffsetProperty, xOffset);
        }
        public static double GetYOffset(FrameworkElement frameworkElement)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            return (double)frameworkElement.GetValue(YOffsetProperty);
        }
        public static void SetYOffset(FrameworkElement frameworkElement, double yOffset)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            frameworkElement.SetValue(YOffsetProperty, yOffset);
        }
        public static bool GetIsDragInProgress(DependencyObject dependencyObject)
        {
            dependencyObject.AssertNotNull("dependencyObject");
            return (bool)dependencyObject.GetValue(IsDragInProgressProperty);
        }
        private static void SetIsDragInProgress(DependencyObject dependencyObject, bool isDragInProgress)
        {
            dependencyObject.AssertNotNull("dependencyObject");
            dependencyObject.SetValue(isDragInProgressPropertyKey, isDragInProgress);
        }
        private static Point? GetDragPoint(FrameworkElement frameworkElement)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            return (Point?)frameworkElement.GetValue(DragPointProperty);
        }
        private static void SetDragPoint(FrameworkElement frameworkElement, Point? dragPoint)
        {
            frameworkElement.AssertNotNull("frameworkElement");
            frameworkElement.SetValue(DragPointProperty, dragPoint);
        }
        private static void OnCanDragChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)dependencyObject;
            if ((bool)e.NewValue)
            {
                frameworkElement.MouseLeftButtonDown += OnFrameworkElementMouseLeftButtonDown;
                frameworkElement.MouseMove += OnFrameworkElementMouseMove;
                frameworkElement.MouseLeftButtonUp += OnFrameworkElementMouseLeftButtonUp;
                var parent = GetDragParent<FrameworkElement>(frameworkElement);
                if (parent == null)
                {
                    frameworkElement.SetCurrentValue(XOffsetProperty, 0d);
                    frameworkElement.SetCurrentValue(YOffsetProperty, 0d);
                }
                else
                {
                    var pointRelativeToParent = frameworkElement.TranslatePoint(new Point(0, 0), parent);
                    frameworkElement.SetCurrentValue(XOffsetProperty, pointRelativeToParent.X);
                    frameworkElement.SetCurrentValue(YOffsetProperty, pointRelativeToParent.Y);
                }
            }
            else
            {
                frameworkElement.MouseLeftButtonDown -= OnFrameworkElementMouseLeftButtonDown;
                frameworkElement.MouseMove -= OnFrameworkElementMouseMove;
                frameworkElement.MouseLeftButtonUp -= OnFrameworkElementMouseLeftButtonUp;
            }
        }
        private static void OnFrameworkElementMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            var parent = GetDragParent<FrameworkElement>(frameworkElement);
            if (parent == null)
            {
                return;
            }
            var previewBeginDragEventArgs = new RoutedEventArgs(PreviewBeginDragEvent);
            frameworkElement.RaiseEvent(previewBeginDragEventArgs);
            if (previewBeginDragEventArgs.Handled)
            {
                return;
            }
            SetIsDragInProgress(frameworkElement, true);
            SetDragPoint(frameworkElement, e.GetPosition(parent));
            frameworkElement.CaptureMouse();
            frameworkElement.RaiseEvent(new RoutedEventArgs(BeginDragEvent));
        }
        private static void OnFrameworkElementMouseMove(object sender, MouseEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            if (frameworkElement.IsMouseCaptured)
            {
                var previewDragEventArgs = new RoutedEventArgs(PreviewDragEvent);
                frameworkElement.RaiseEvent(previewDragEventArgs);
                if (previewDragEventArgs.Handled)
                {
                    return;
                }
                var parent = GetDragParent<FrameworkElement>(frameworkElement);
                if (parent == null)
                {
                    return;
                }
                var currentPointRelativeToParent = e.GetPosition(parent);
                var dragPoint = GetDragPoint(frameworkElement);
                Debug.Assert(dragPoint.HasValue, "dragPoint should be set.");
                frameworkElement.SetCurrentValue(XOffsetProperty, GetXOffset(frameworkElement) + (currentPointRelativeToParent.X - dragPoint.Value.X));
                frameworkElement.SetCurrentValue(YOffsetProperty, GetYOffset(frameworkElement) + (currentPointRelativeToParent.Y - dragPoint.Value.Y));
                SetDragPoint(frameworkElement, currentPointRelativeToParent);
                frameworkElement.RaiseEvent(new RoutedEventArgs(DragEvent));
            }
        }
        private static void OnFrameworkElementMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            if (frameworkElement.IsMouseCaptured)
            {
                frameworkElement.RaiseEvent(new RoutedEventArgs(PreviewEndDragEvent));
                SetDragPoint(frameworkElement, null);
                frameworkElement.ReleaseMouseCapture();
                frameworkElement.RaiseEvent(new RoutedEventArgs(EndDragEvent));
                SetIsDragInProgress(frameworkElement, false);
            }
        }
        private static T GetDragParent<T>(DependencyObject dependencyObject)
            where T : DependencyObject
        {
            var dragParent = GetDragParent(dependencyObject) as T;
            if (dragParent != null)
            {
                return dragParent;
            }
            var parent = VisualTreeHelper.GetParent(dependencyObject);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return (T)parent;
        }
    }

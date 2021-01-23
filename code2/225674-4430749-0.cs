    using System;
    using System.Windows;
    using System.Windows.Threading;
    /// <summary>
    /// Represents a particular mouse button being pressed
    /// </summary>
    public enum MouseButtonType
    {
        /// <summary>
        /// Left mouse button
        /// </summary>
        Left,
        /// <summary>
        /// Right mouse button
        /// </summary>
        Right,
        /// <summary>
        /// Either mouse button
        /// </summary>
        Both
    }
    /// <summary>
    /// Provides functionality for detecting when a mouse button has been held
    /// </summary>
    public class MouseDownWait
    {
        /// <summary>
        /// States which mouse button press should be detected
        /// </summary>
        public static readonly DependencyProperty MouseButtonProperty =
            DependencyProperty.RegisterAttached(
                "MouseButton",
                typeof(MouseButtonType),
                typeof(MouseDownWait),
                new PropertyMetadata(
                    (o, e) =>
                        {
                        var ctrl = o as UIElement;
                        if (ctrl != null)
                        {
                            new MouseDownWait(ctrl);
                        }
                    }));
        /// <summary>
        /// The time (in milliseconds) to wait before detecting mouse press
        /// </summary>
        public static readonly DependencyProperty TimeProperty = DependencyProperty.RegisterAttached(
            "Time", typeof(int), typeof(MouseDownWait), new FrameworkPropertyMetadata(0, OnTimePropertyChanged));
        /// <summary>
        /// Method to be called when the mouse press is detected
        /// </summary>
        public static readonly DependencyProperty DetectMethodProperty =
            DependencyProperty.RegisterAttached(
                "DetectMethod",
                typeof(string),
                typeof(MouseDownWait));
        /// <summary>
        /// Target object for the method calls (if not the datacontext)
        /// </summary>
        public static readonly DependencyProperty MethodTargetProperty =
            DependencyProperty.RegisterAttached("MethodTarget", typeof(object), typeof(MouseDownWait));      
        /// <summary>
        /// The timer used to detect mouse button holds
        /// </summary>
        private static readonly DispatcherTimer Timer = new DispatcherTimer();
        /// <summary>
        /// The element containing the attached property
        /// </summary>
        private readonly UIElement element;
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseDownWait"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        public MouseDownWait(UIElement element)
        {
            this.element = element;
            if (this.element == null)
            {
                return;
            }
            this.element.MouseLeftButtonDown += ElementMouseLeftButtonDown;
            this.element.MouseLeftButtonUp += ElementMouseLeftButtonUp;
            this.element.MouseRightButtonDown += ElementMouseRightButtonDown;
            this.element.MouseRightButtonUp += ElementMouseRightButtonUp;
            this.element.MouseDown += ElementMouseDown;
            this.element.MouseUp += ElementMouseUp;
            Timer.Tick += this.TimerTick;
        }
        /// <summary>
        /// Gets the mouse button type
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The mouse button type
        /// </returns>
        public static MouseButtonType GetMouseButton(UIElement element)
        {
            return (MouseButtonType)element.GetValue(MouseButtonProperty);
        }
        /// <summary>
        /// Sets the mouse button type
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The type of mouse button</param>
        public static void SetMouseButton(UIElement element, MouseButtonType value)
        {
            element.SetValue(MouseButtonProperty, value);
        }
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The time in milliseconds</returns>
        public static int GetTime(UIElement element)
        {
            return (int)element.GetValue(TimeProperty);
        }
        /// <summary>
        /// Sets the time.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetTime(UIElement element, int value)
        {
            element.SetValue(TimeProperty, value);
        }
        /// <summary>
        /// Sets the detect method
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetDetectMethod(UIElement element, string value)
        {
            element.SetValue(DetectMethodProperty, value);
        }
        /// <summary>
        /// Gets the detect method
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>method name</returns>
        public static string GetDetectMethod(UIElement element)
        {
            return (string)element.GetValue(DetectMethodProperty);
        }
        /// <summary>
        /// Gets the method target.
        /// </summary>
        /// <param name="ctrl">The CTRL .</param>
        /// <returns>method target (i.e. viewmodel)</returns>
        public static object GetMethodTarget(UIElement ctrl)
        {
            var result = ctrl.GetValue(MethodTargetProperty);
            if (result == null)
            {
                var fe = ctrl as FrameworkElement;
                if (fe != null)
                {
                    result = fe.DataContext;
                }
            }
            return result;
        }
        /// <summary>
        /// Sets the method target.
        /// </summary>
        /// <param name="ctrl">The CTRL .</param>
        /// <param name="value">The value.</param>
        public static void SetMethodTarget(UIElement ctrl, object value)
        {
            ctrl.SetValue(MethodTargetProperty, value);
        }
        /// <summary>
        /// Called when the time property changes.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Timer.Interval = TimeSpan.FromMilliseconds((int)e.NewValue);
        }
        /// <summary>
        /// Called when a mouse down is detected
        /// </summary>
        private static void MouseDownDetected()
        {
            Timer.Start();
        }
        /// <summary>
        /// Called when a mouse up is detected
        /// </summary>
        private static void MouseUpDetected()
        {
            Timer.Stop();
        }
        /// <summary>
        /// Checks if the mouse button has been detected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="type">The mouse button type.</param>
        /// <param name="mouseDown">if set to <c>true</c> [mouse down].</param>
        private static void CheckMouseDetected(object sender, MouseButtonType type, bool mouseDown)
        {
            var uiElement = sender as UIElement;
            if (uiElement == null)
            {
                return;
            }
            if (GetMouseButton(uiElement) != type)
            {
                return;
            }
            if (mouseDown)
            {
                MouseDownDetected();
            }
            else
            {
                MouseUpDetected();
            }
        }
        /// <summary>
        /// Called when the mouse down event fires
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void ElementMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckMouseDetected(sender, MouseButtonType.Both, true);
        }
        /// <summary>
        /// Called when the mouse up event fires
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void ElementMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckMouseDetected(sender, MouseButtonType.Both, false);
        }
        /// <summary>
        /// Called when the left mouse down event fires
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void ElementMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckMouseDetected(sender, MouseButtonType.Left, true);
        }
        /// <summary>
        /// Called when the left mouse up event fires
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void ElementMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckMouseDetected(sender, MouseButtonType.Left, false);
        }
        /// <summary>
        /// Called when the right mouse down event fires
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void ElementMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckMouseDetected(sender, MouseButtonType.Right, true);
        }
        /// <summary>
        /// Called when the right mouse up event fires
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void ElementMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckMouseDetected(sender, MouseButtonType.Right, false);
        }
        /// <summary>
        /// Called on each timer tick
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TimerTick(object sender, EventArgs e)
        {
            Timer.Stop();
            var method = GetDetectMethod(this.element);
            if (!string.IsNullOrEmpty(method))
            {
                this.InvokeMethod(method);
            }
        }
        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        private void InvokeMethod(string methodName, params object[] parameters)
        {
            var target = GetMethodTarget(this.element);
            var targetMethod = target.GetType().GetMethod(methodName);
            if (targetMethod == null)
            {
                throw new MissingMethodException(methodName);
            }
            targetMethod.Invoke(target, parameters);
        }
    }

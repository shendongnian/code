    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using JetBrains.Annotations;
    
    namespace WpfExtensions
    {
        public static class MouseHorizontalWheelEnabler
        {
            private static readonly HashSet<IntPtr> _HookedWindows = new HashSet<IntPtr>();
    
            public static bool IsMouseHorizontalWheelEnabled(IntPtr handle) {
                return _HookedWindows.Contains(handle);
            }
    
            public static void EnableMouseHorizontalWheel([NotNull] Window window) {
                if (window == null) {
                    throw new ArgumentNullException(nameof(window));
                }
    
                IntPtr handle = new WindowInteropHelper(window).Handle;
                EnableMouseHorizontalWheel(handle);
            }
    
            public static void EnableMouseHorizontalWheel(IntPtr handle) {
                if (_HookedWindows.Contains(handle)) {
                    return;
                }
    
                _HookedWindows.Add(handle);
                HwndSource source = HwndSource.FromHwnd(handle);
                source.AddHook(WndProcHook);
            }
    
            public static void DisableMouseHorizontalWheel(IntPtr handle) {
                if (!_HookedWindows.Contains(handle)) {
                    return;
                }
    
                HwndSource source = HwndSource.FromHwnd(handle);
                source.RemoveHook(WndProcHook);
                _HookedWindows.Remove(handle);
            }
    
            public static void DisableMouseHorizontalWheel([NotNull] Window window) {
                if (window == null) {
                    throw new ArgumentNullException(nameof(window));
                }
    
                IntPtr handle = new WindowInteropHelper(window).Handle;
                DisableMouseHorizontalWheel(handle);
            }
    
    
            private static void HandleMouseHorizontalWheel(IntPtr wParam) {
                int tilt = Win32.HiWord(wParam);
                if (tilt == 0) {
                    return;
                }
    
                IInputElement element = Mouse.DirectlyOver;
                if (element == null) {
                    return;
                }
    
                if (!(element is UIElement)) {
                    element = VisualTreeHelpers.FindAncestor<UIElement>(element as DependencyObject);
                }
                if (element == null) {
                    return;
                }
    
                var ev = new MouseHorizontalWheelEventArgs(Mouse.PrimaryDevice, Environment.TickCount, tilt) {
                    RoutedEvent = PreviewMouseHorizontalWheelEvent
                    //Source = handledWindow
                };
    
                // first raise preview
                element.RaiseEvent(ev);
                if (ev.Handled) {
                    return;
                }
    
                // then bubble it
                ev.RoutedEvent = MouseHorizontalWheelEvent;
                element.RaiseEvent(ev);
            }
    
            private static IntPtr WndProcHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
                // ransform horizontal mouse wheel messages 
                switch (msg) {
                    case Win32.WM_MOUSEHWHEEL:
                        HandleMouseHorizontalWheel(wParam);
                        break;
                }
                return IntPtr.Zero;
            }
    
            private static class Win32
            {
                // ReSharper disable InconsistentNaming
                public const int WM_MOUSEHWHEEL = 0x020E;
                // ReSharper restore InconsistentNaming
    
                public static int GetIntUnchecked(IntPtr value) {
                    return IntPtr.Size == 8 ? unchecked((int)value.ToInt64()) : value.ToInt32();
                }
    
                public static int HiWord(IntPtr ptr) {
                    return unchecked((short)(((uint)GetIntUnchecked(ptr)) >> 16));
                }
            }
    
            #region MouseWheelHorizontal Event
    
            public static readonly RoutedEvent MouseHorizontalWheelEvent =
              EventManager.RegisterRoutedEvent("MouseHorizontalWheel", RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                typeof(MouseHorizontalWheelEnabler));
    
            public static void AddMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler) {
                var uie = d as UIElement;
                uie?.AddHandler(MouseHorizontalWheelEvent, handler);
            }
    
            public static void RemoveMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler) {
                var uie = d as UIElement;
                uie?.RemoveHandler(MouseHorizontalWheelEvent, handler);
            }
    
            #endregion
    
            #region PreviewMouseWheelHorizontal Event
    
            public static readonly RoutedEvent PreviewMouseHorizontalWheelEvent =
              EventManager.RegisterRoutedEvent("PreviewMouseHorizontalWheel", RoutingStrategy.Tunnel, typeof(RoutedEventHandler),
                typeof(MouseHorizontalWheelEnabler));
    
            public static void AddPreviewMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler) {
                var uie = d as UIElement;
                uie?.AddHandler(PreviewMouseHorizontalWheelEvent, handler);
            }
    
            public static void RemovePreviewMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler) {
                var uie = d as UIElement;
                uie?.RemoveHandler(PreviewMouseHorizontalWheelEvent, handler);
            }
    
            #endregion
        }
    }

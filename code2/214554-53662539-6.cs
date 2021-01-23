	using System;
	using System.Collections.Generic;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Interop;
	namespace MyTestProject
	{
		public class TiltWheelHorizontalScroller
		{
			public static bool GetEnableTiltWheelScroll(DependencyObject obj) => (bool)obj.GetValue(EnableTiltWheelScrollProperty);
			public static void SetEnableTiltWheelScroll(DependencyObject obj, bool value) => obj.SetValue(EnableTiltWheelScrollProperty, value);
			public static readonly DependencyProperty EnableTiltWheelScrollProperty =
					DependencyProperty.RegisterAttached("EnableTiltWheelScroll", typeof(bool), typeof(TiltWheelHorizontalScroller), new UIPropertyMetadata(false, OnHorizontalMouseWheelScrollingEnabledChanged));
			static HashSet<int> controls = new HashSet<int>();
			static void OnHorizontalMouseWheelScrollingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
			{
				Control control = d as Control;
				if (control != null && GetEnableTiltWheelScroll(d) && controls.Add(control.GetHashCode()))
				{
					control.MouseEnter += (sender, e) =>
					{
						var scrollViewer = d.FindChildOfType<ScrollViewer>();
						if (scrollViewer != null)
						{
							new TiltWheelMouseScrollHelper(scrollViewer, d);
						}
					};
				}
			}
		}
		class TiltWheelMouseScrollHelper
		{
			/// <summary>
			/// multiplier of how far to scroll horizontally. Change as desired.
			/// </summary>
			private const int scrollFactor = 3;
			private const int WM_MOUSEHWEEL = 0x20e;
			ScrollViewer scrollViewer;
			HwndSource hwndSource;
			HwndSourceHook hook;
			static HashSet<int> scrollViewers = new HashSet<int>();
			public TiltWheelMouseScrollHelper(ScrollViewer scrollViewer, DependencyObject d)
			{
				this.scrollViewer = scrollViewer;
				hwndSource = PresentationSource.FromDependencyObject(d) as HwndSource;
				hook = WindowProc;
				hwndSource?.AddHook(hook);
				if (scrollViewers.Add(scrollViewer.GetHashCode()))
				{
					scrollViewer.MouseLeave += (sender, e) =>
					{
						hwndSource.RemoveHook(hook);
					};
				}
			}
			IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
			{
				switch (msg)
				{
					case WM_MOUSEHWEEL:
						Scroll(wParam);
						handled = true;
						break;
				}
				return IntPtr.Zero;
			}
			private void Scroll(IntPtr wParam)
			{
				int delta = (HIWORD(wParam) > 0 ? 1 : -1) * scrollFactor;
				scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + delta);
			}
			private static int HIWORD(IntPtr ptr) => (short)((ptr.ToInt32() >> 16) & 0xFFFF);
		}
	}

<Window x:Class="WpfApp4.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:WpfApp4"
    Title="MainWindow"
    Width="800"
    Height="450"
    UseLayoutRounding="True">
    <Window.DataContext>
        <local:MainWindowViewModel />
    </Window.DataContext>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <Control x:Name="CountDownVisual"
            Grid.Row="1"
            Height="30"
            Margin="0">
            <Control.Template>
                <ControlTemplate>
                    <Grid x:Name="RootElement">
                        <Grid x:Name="CountDownBarRootElement"
                            local:CountDownBarAnimationBehavior.IsActive="{Binding ShowUiTimer}"
                            local:CountDownBarAnimationBehavior.ParentElement="{Binding ElementName=RootElement}"
                            local:CountDownBarAnimationBehavior.TargetElement="{Binding ElementName=CountDownBar}">
                            <Rectangle x:Name="CountDownBar"
                                HorizontalAlignment="Left"
                                Fill="#FFA4B5BF" />
                        </Grid>
                    </Grid>
                </ControlTemplate>
            </Control.Template>
        </Control>
    </Grid>
</Window>
Attached Behavior
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
namespace WpfApp4
{
	public static class CountDownBarAnimationBehavior
	{
		private static Storyboard sb;
		#region IsActive (DependencyProperty)
		public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(CountDownBarAnimationBehavior), new FrameworkPropertyMetadata(false, OnIsActiveChanged));
		public static bool GetIsActive(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsActiveProperty);
		}
		public static void SetIsActive(DependencyObject obj, bool value)
		{
			obj.SetValue(IsActiveProperty, value);
		}
		private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
            if (!(d is FrameworkElement control))
			{
				return;
			}
			if((bool)e.NewValue)
			{
                if (GetParentElement(control) != null)
                {
                    StartAnimation(control);
                }
                else
                {
                    // If IsActive is set to true and the other properties haven't
                    // been updated yet, defer the animation until render time.
                    control.Dispatcher?.BeginInvoke((Action) (() => { StartAnimation(control); }), DispatcherPriority.Render);
                }
            }
			else
			{
				StopAnimation();
			}
		}
		#endregion
		#region ParentElement (DependencyProperty)
		public static readonly DependencyProperty ParentElementProperty = DependencyProperty.RegisterAttached("ParentElement", typeof(FrameworkElement), typeof(CountDownBarAnimationBehavior), new FrameworkPropertyMetadata(null, OnParentElementChanged));
		public static FrameworkElement GetParentElement(DependencyObject obj)
		{
			return (FrameworkElement)obj.GetValue(ParentElementProperty);
		}
		public static void SetParentElement(DependencyObject obj, FrameworkElement value)
		{
			obj.SetValue(ParentElementProperty, value);
		}
		private static void OnParentElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
            if(!(d is FrameworkElement fe))
			{
				return;
			}
            // You can wire up events here if you want to react to size changes, etc.
		}
		private static void OnParentElementSizeChanged(object sender, SizeChangedEventArgs e)
		{
            if (!(sender is FrameworkElement fe))
			{
				return;
			}
			if (GetIsActive(fe))
			{
				StopAnimation();
				StartAnimation(fe);
			}
		}
        #endregion
        #region TargetElement (DependencyProperty)
        public static readonly DependencyProperty TargetElementProperty = DependencyProperty.RegisterAttached("TargetElement", typeof(FrameworkElement), typeof(CountDownBarAnimationBehavior), new FrameworkPropertyMetadata(null));
		public static FrameworkElement GetTargetElement(DependencyObject obj)
		{
			return (FrameworkElement)obj.GetValue(TargetElementProperty);
		}
		public static void SetTargetElement(DependencyObject obj, FrameworkElement value)
		{
			obj.SetValue(TargetElementProperty, value);
		}
		#endregion
		private static void StartAnimation(DependencyObject d)
		{
			var parent = GetParentElement(d);
			var target = GetTargetElement(d);
			if (parent == null || target == null)
			{
				return;
			}
			sb = new Storyboard();
			var da = new DoubleAnimation();
			Storyboard.SetTarget(da, target);
			Storyboard.SetTargetProperty(da, new PropertyPath("Width"));
            da.AutoReverse = false;
            da.Duration = new Duration(new TimeSpan(0, 1, 0));
            da.From = parent.ActualWidth;
            da.To = 0d;
			sb.Children.Add(da);
			sb.Begin();
		}
		private static void StopAnimation()
        {
            sb?.Stop();
        }
	}
}

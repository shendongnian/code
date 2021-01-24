    public class AnimatedMarginBehavior : Behavior<FrameworkElement>
	{
		private ThicknessAnimation Animation = new ThicknessAnimation();
		public FrameworkElement ElementA
		{
			get { return GetValue(ElementAProperty) as FrameworkElement; }
			set { SetValue(ElementAProperty, value); }
		}
		public static readonly DependencyProperty ElementAProperty =
			DependencyProperty.Register("ElementA", typeof(FrameworkElement), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(FrameworkElement), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		public FrameworkElement ElementB
		{
			get { return GetValue(ElementBProperty) as FrameworkElement; }
			set { SetValue(ElementBProperty, value); }
		}
		public static readonly DependencyProperty ElementBProperty =
			DependencyProperty.Register("ElementB", typeof(FrameworkElement), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(FrameworkElement), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		public Expander Parent
		{
			get { return GetValue(ParentProperty) as Expander; }
			set { SetValue(ParentProperty, value); }
		}
		public static readonly DependencyProperty ParentProperty =
			DependencyProperty.Register("Parent", typeof(Expander), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(Expander), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		public Grid Grid
		{
			get { return GetValue(GridProperty) as Grid; }
			set { SetValue(GridProperty, value); }
		}
		public static readonly DependencyProperty GridProperty =
			DependencyProperty.Register("Grid", typeof(Grid), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(Grid), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		private void OnBindingChanged(DependencyPropertyChangedEventArgs e)
		{
			if (this.ElementA == null)
				return;
			if (this.ElementB == null)
				return;
			if (this.Parent == null)
				return;
			if (this.Grid == null)
				return;
			// set initial position based on whether or not the control is expanded
			var currentElement = this.Parent.IsExpanded ? this.ElementB : this.ElementA;
			UIElement container = VisualTreeHelper.GetParent(this.Grid) as UIElement;
			var pos = currentElement.TranslatePoint(new Point(0, 0), container);
			this.AssociatedObject.SetValue(FrameworkElement.MarginProperty, new Thickness(pos.X-1, pos.Y-1, 0, 0));
			// get notification when the expander changes state
			this.Parent.Collapsed += (_s1, _e1) =>
			{
				container = VisualTreeHelper.GetParent(this.Grid) as UIElement;
				var from = this.ElementB.TranslatePoint(new Point(0, 0), container);
				var to = this.ElementA.TranslatePoint(new Point(0, 0), container);
				this.Animation.From = new Thickness(from.X, from.Y, 0, 0);
				this.Animation.To = new Thickness(to.X, to.Y, 0, 0);
				this.Animation.Duration = TimeSpan.FromMilliseconds(500);
				this.Animation.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut };
				this.AssociatedObject.BeginAnimation(FrameworkElement.MarginProperty, this.Animation);
			};
			this.Parent.Expanded += (_s2, _e2) =>
			{
				container = VisualTreeHelper.GetParent(this.Grid) as UIElement;
				var from = this.ElementA.TranslatePoint(new Point(0, 0), container);
				var to = this.ElementB.TranslatePoint(new Point(0, 0), container);
				this.Animation.From = new Thickness(from.X, from.Y, 0, 0);
				this.Animation.To = new Thickness(to.X, to.Y, 0, 0);
				this.Animation.Duration = TimeSpan.FromMilliseconds(500);
				this.Animation.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut };
				this.AssociatedObject.BeginAnimation(FrameworkElement.MarginProperty, this.Animation);
			};
		}
	}

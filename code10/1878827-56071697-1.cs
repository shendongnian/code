    public class AnimatedMarginBehavior : Behavior<FrameworkElement>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
		}
		public object ElementA
		{
			get { return GetValue(ElementAProperty); }
			set { SetValue(ElementAProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Binding.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ElementAProperty =
			DependencyProperty.Register("ElementA", typeof(object), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(object), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		public object ElementB
		{
			get { return GetValue(ElementBProperty); }
			set { SetValue(ElementBProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Binding.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ElementBProperty =
			DependencyProperty.Register("ElementB", typeof(object), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(object), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		public object Parent
		{
			get { return GetValue(ParentProperty); }
			set { SetValue(ParentProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Binding.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ParentProperty =
			DependencyProperty.Register("Parent", typeof(object), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(object), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		public object Grid
		{
			get { return GetValue(GridProperty); }
			set { SetValue(GridProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Binding.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty GridProperty =
			DependencyProperty.Register("Grid", typeof(object), typeof(AnimatedMarginBehavior),
				new PropertyMetadata(default(object), (d, e) => (d as AnimatedMarginBehavior).OnBindingChanged(e)));
		private void OnBindingChanged(DependencyPropertyChangedEventArgs e)
		{
			var elementA = this.ElementA as FrameworkElement;
			if (ElementA == null)
				return;
			var elementB = this.ElementB as FrameworkElement;
			if (ElementB == null)
				return;
			var parent = this.Parent as Expander;
			if (parent == null)
				return;
			var grid = this.Grid as FrameworkElement;
			if (grid == null)
				return;
			// set initial position based on whether or not the control is expanded
			var currentElement = parent.IsExpanded ? elementB : elementA;
			UIElement container = VisualTreeHelper.GetParent(grid) as UIElement;
			var pos = currentElement.TranslatePoint(new Point(0, 0), container);
			this.AssociatedObject.SetValue(FrameworkElement.MarginProperty, new Thickness(pos.X-1, pos.Y-1, 0, 0));
			// get notification when the expander changes state
			parent.Collapsed += (_s1, _e1) =>
			{
				container = VisualTreeHelper.GetParent(grid) as UIElement;
				var from = elementB.TranslatePoint(new Point(0, 0), container);
				var to = elementA.TranslatePoint(new Point(0, 0), container);
				var anim = new ThicknessAnimation();
				anim.From = new Thickness(from.X, from.Y, 0, 0);
				anim.To = new Thickness(to.X, to.Y, 0, 0);
				anim.Duration = TimeSpan.FromMilliseconds(500);
				anim.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut };
				this.AssociatedObject.BeginAnimation(FrameworkElement.MarginProperty, anim);				
			};
			parent.Expanded += (_s2, _e2) =>
			{
				container = VisualTreeHelper.GetParent(grid) as UIElement;
				var from = elementA.TranslatePoint(new Point(0, 0), container);
				var to = elementB.TranslatePoint(new Point(0, 0), container);
				var anim = new ThicknessAnimation();
				anim.From = new Thickness(from.X, from.Y, 0, 0);
				anim.To = new Thickness(to.X, to.Y, 0, 0);
				anim.Duration = TimeSpan.FromMilliseconds(500);
				anim.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut };
				this.AssociatedObject.BeginAnimation(FrameworkElement.MarginProperty, anim);
			};
		}
	}

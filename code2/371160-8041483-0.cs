		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.Register("Title", typeof(string), typeof(ComparisonReport), new PropertyMetadata(null, OnTitleChanged));
		private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var o = d as ComparisonReport;
			if (o != null && e.NewValue != null)
			{
				var n = ((ComparisonReport)d);
				n.RadChart1.DefaultView.ChartArea.AxisX.Title = String.Format("{0} Comparison", e.NewValue);
			}
		}

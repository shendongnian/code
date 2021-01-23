		public static readonly DependencyProperty SelectAllPathProperty =
				DependencyProperty.RegisterAttached("SelectAllPath", typeof(string), typeof(AttachedProperties), new UIPropertyMetadata(null, OnAttached));
		public static string GetSelectAllPath(DependencyObject obj)
		{
			return (string)obj.GetValue(SelectAllPathProperty);
		}
		public static void SetSelectAllPath(DependencyObject obj, string value)
		{
			obj.SetValue(SelectAllPathProperty, value);
		}
		public static readonly DependencyProperty SelectAllItemsSourceProperty =
				DependencyProperty.RegisterAttached("SelectAllItemsSource", typeof(IEnumerable), typeof(AttachedProperties), new UIPropertyMetadata(null));
		public static IEnumerable GetSelectAllItemsSource(DependencyObject obj)
		{
			return (IEnumerable)obj.GetValue(SelectAllItemsSourceProperty);
		}
		public static void SetSelectAllItemsSource(DependencyObject obj, IEnumerable value)
		{
			obj.SetValue(SelectAllItemsSourceProperty, value);
		}
		private static void OnAttached(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var cb = o as CheckBox;
			if (cb.IsLoaded)
			{
				Attach(cb);
			}
			else
			{
				cb.Loaded += (s, _) => Attach(cb);
			}
		}
		private static void Attach(CheckBox checkBox)
		{
			var itemsSource = GetSelectAllItemsSource(checkBox);
			if (itemsSource is INotifyCollectionChanged)
			{
				var isAsIcc = itemsSource as INotifyCollectionChanged;
				isAsIcc.CollectionChanged += (s, ccea) =>
					{
						RebuildBindings(checkBox);
					};
			}
			RebuildBindings(checkBox);
			checkBox.Click += (s, cea) =>
				{
					if (!checkBox.IsChecked.HasValue)
					{
						checkBox.IsChecked = false;
					}
				};
		}
		private static void RebuildBindings(CheckBox checkBox)
		{
			MultiBinding binding = new MultiBinding();
			var itemsSource = GetSelectAllItemsSource(checkBox);
			var path = GetSelectAllPath(checkBox);
			foreach (var item in itemsSource)
			{
				binding.Bindings.Add(new Binding(path) { Source = item });
			}
			binding.Converter = new CheckedConverter();
			checkBox.SetBinding(CheckBox.IsCheckedProperty, binding);
		}
		private class CheckedConverter : IMultiValueConverter
		{
			public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				if (values.Length == 0)
				{
					return null;
				}
				else
				{
					bool first = (bool)values[0];
					foreach (var item in values.Skip(1).Cast<bool>())
					{
						if (first != item)
						{
							return null;
						}
					}
					return first;
				}
			}
			public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
			{
				var output = (bool?)value;
				var outarray = new object[targetTypes.Length];
				if (output.HasValue)
				{
					for (int i = 0; i < outarray.Length; i++)
					{
						outarray[i] = output.Value;
					}
				}
				return outarray;
			}
		}

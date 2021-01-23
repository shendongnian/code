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
		private static void OnAttached(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var cb = o as CheckBox;
			// Needs more closures.
			Action attach = () =>
				{
					IEnumerable itemsSource = cb.Tag as IEnumerable;
					if (itemsSource == null) throw new Exception("ItemsSource for attached property 'SelectAllPath' not found.");
					string path = e.NewValue as string;
					cb.Checked += new RoutedEventHandler(cb_Checked);
					cb.Unchecked += new RoutedEventHandler(cb_Unchecked);
					PropertyChangedEventHandler propertyChangeHandler = (i, pcea) =>
					{
						if (pcea.PropertyName == path)
						{
							UpdateCb(cb, itemsSource.Cast<object>(), path);
						}
					};
					Action<object> tryAttachHandlerAction = (item) =>
						{
							if (item is INotifyPropertyChanged)
							{
								var asInpc = item as INotifyPropertyChanged;
								asInpc.PropertyChanged += propertyChangeHandler;
							}
						};
					foreach (var item in itemsSource)
					{
						tryAttachHandlerAction(item);
					}
					if (itemsSource is INotifyCollectionChanged)
					{
						var asCC = itemsSource as INotifyCollectionChanged;
						asCC.CollectionChanged += (s, cce) =>
							{
								if (cce.Action == NotifyCollectionChangedAction.Add)
								{
									foreach (var item in cce.NewItems)
									{
										tryAttachHandlerAction(item);
									}
								}
							};
					}
					UpdateCb(cb, itemsSource.Cast<object>(), path);
				};
			if (cb.IsLoaded)
			{
				attach();
			}
			else
			{
				cb.Loaded += (s, esub) => attach();
			}
		}
		private static void UpdateCb(CheckBox cb, IEnumerable<object> items, string path)
		{
			Type itemType = null;
			PropertyInfo propInfo = null;
			bool? previous = null;
			bool indeterminate = false;
			foreach (var item in items)
			{
				if (propInfo == null)
				{
					itemType = item.GetType();
					propInfo = itemType.GetProperty(path);
				}
				if (item.GetType() == itemType)
				{
					if (!previous.HasValue)
					{
						previous = (bool)propInfo.GetValue(item, null);
					}
					else
					{
						if (previous != (bool)propInfo.GetValue(item, null))
						{
							indeterminate = true;
							break;
						}
					}
				}
			}
			if (indeterminate)
			{
				cb.IsChecked = null;
			}
			else
			{
				if (previous.HasValue)
				{
					cb.IsChecked = previous.Value;
				}
			}
		}
		static void cb_Unchecked(object sender, RoutedEventArgs e)
		{
			SetValues(sender, false);
		}
		static void cb_Checked(object sender, RoutedEventArgs e)
		{
			SetValues(sender, true);
		}
		private static void SetValues(object sender, bool value)
		{
			var cb = sender as CheckBox;
			IEnumerable itemsSource = cb.Tag as IEnumerable;
			Type itemType = null;
			PropertyInfo propInfo = null;
			foreach (var item in itemsSource)
			{
				if (propInfo == null)
				{
					itemType = item.GetType();
					propInfo = itemType.GetProperty(GetSelectAllPath(cb));
				}
				if (item.GetType() == itemType)
				{
					propInfo.SetValue(item, value, null);
				}
			}
		}

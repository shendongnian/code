    /// <summary>
	///     Behavior that makes the <see cref="System.Windows.Controls.TreeView.SelectedItem" /> bindable.
	/// </summary>
	internal class BindableTreeViewSelectedItemBehavior : Behavior<TreeView>
	{
		#region " SelectedItem "
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(BindableTreeViewSelectedItemBehavior), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));
		public object SelectedItem
		{
			get { return this.GetValue(SelectedItemProperty); }
			set { this.SetValue(SelectedItemProperty, value); }
		}
		private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is TreeViewItem item)
			{
				item.SetValue(TreeViewItem.IsSelectedProperty, true);
				item.Focus();
				return;
			}
			if (sender is BindableTreeViewSelectedItemBehavior behavior)
			{
				var treeView = behavior.AssociatedObject;
				if (treeView != null)
				{
					item = GetTreeViewItem(treeView, e.NewValue);
					if (item != null)
					{
						item.IsSelected = true;
						item.Focus();
					}
				}
			}
		}
		#endregion
		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.SelectedItemChanged += this.OnTreeViewSelectedItemChanged;
		}
		private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			this.SelectedItem = e.NewValue;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			if (this.AssociatedObject != null)
			{
				this.AssociatedObject.SelectedItemChanged -= this.OnTreeViewSelectedItemChanged;
			}
		}
		#region " GetBringIndexIntoView "
		/// <summary>
		/// GetBringIndexIntoView
		/// </summary>
		/// <param name="itemsHostPanel"></param>
		/// <returns>Action<int></returns>
		private static Action<int> GetBringIndexIntoView(Panel itemsHostPanel)
		{
			if (itemsHostPanel is VirtualizingStackPanel virtualizingPanel)
			{
				var method = virtualizingPanel.GetType().GetMethod("BringIndexIntoView", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(int) }, null);
				if (method != null)
				{
					return i => method.Invoke(virtualizingPanel, new object[] { i });
				}
			}
			return null;
		}
		#endregion
		#region " GetTreeViewItem "
		/// <summary>
		/// GetTreeViewItem
		/// Recursively search for an item in this subtree.
		/// </summary>
		/// <param name="container">The parent ItemsControl. This can be a TreeView or a TreeViewItem.</param>
		/// <param name="item">The item to search for.</param>
		/// <returns>TreeViewItem</returns>
		private static TreeViewItem GetTreeViewItem(ItemsControl container, object item)
		{
			if (container != null)
			{
				if (container.DataContext == item)
				{
					return container as TreeViewItem;
				}
				// Expand the current container
				if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
				{
					container.SetValue(TreeViewItem.IsExpandedProperty, true);
				}
				// Try to generate the ItemsPresenter and the ItemsPanel.
				// by calling ApplyTemplate.  Note that in the 
				// virtualizing case even if the item is marked 
				// expanded we still need to do this step in order to 
				// regenerate the visuals because they may have been virtualized away.
				container.ApplyTemplate();
				var itemsPresenter = (ItemsPresenter)container.Template.FindName("ItemsHost", container);
				if (itemsPresenter != null)
				{
					itemsPresenter.ApplyTemplate();
				}
				else
				{
					// The Tree template has not named the ItemsPresenter, 
					// so walk the descendents and find the child.
					itemsPresenter = container.GetVisualDescendant<ItemsPresenter>();
					if (itemsPresenter == null)
					{
						container.UpdateLayout();
						itemsPresenter = container.GetVisualDescendant<ItemsPresenter>();
					}
				}
				if (itemsPresenter != null)
				{
					var itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
					// Ensure that the generator for this panel has been created.
    #pragma warning disable 168
					var children = itemsHostPanel.Children;
    #pragma warning restore 168
					var bringIndexIntoView = GetBringIndexIntoView(itemsHostPanel);
					for (int i = 0, count = container.Items.Count; i < count; i++)
					{
						TreeViewItem subContainer;
						if (bringIndexIntoView != null)
						{
							// Bring the item into view so 
							// that the container will be generated.
							bringIndexIntoView(i);
							subContainer = (TreeViewItem)container.ItemContainerGenerator.ContainerFromIndex(i);
						}
						else
						{
							subContainer = (TreeViewItem)container.ItemContainerGenerator.ContainerFromIndex(i);
							// Bring the item into view to maintain the 
							// same behavior as with a virtualizing panel.
							subContainer.BringIntoView();
						}
						if (subContainer == null)
						{
							continue;
						}
						// Search the next level for the object.
						var resultContainer = GetTreeViewItem(subContainer, item);
						if (resultContainer != null)
						{
							return resultContainer;
						}
						// The object is not under this TreeViewItem
						// so collapse it.
						subContainer.IsExpanded = false;
					}
				}
			}
			return null;
		}
		#endregion
	}

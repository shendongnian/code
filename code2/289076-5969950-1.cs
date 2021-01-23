	public class ModelTreeView : TreeView
	{
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ModelTreeViewItem();
		}
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is ModelTreeViewItem;
		}
	}
	public class ModelTreeViewItem : TreeViewItem
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item needs focus.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty NeedsFocusProperty = DependencyProperty.Register("NeedsFocus", typeof(bool), typeof(ModelTreeViewItem));
		public bool NeedsFocus
		{
			get
			{
				return (bool)GetValue(NeedsFocusProperty);
			}
			set
			{
				SetValue(NeedsFocusProperty, value);
			}
		}
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ModelTreeViewItem();
		}
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is ModelTreeViewItem;
		}
	}

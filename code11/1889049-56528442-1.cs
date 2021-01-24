    /// <summary>
	/// BindingProxy
	/// Used to get Parent datacontext within Child control.
	/// </summary>
	public class BindingProxy : Freezable
	{
		#region " Overrides Of Freezable "
		protected override Freezable CreateInstanceCore()
		{
			return new BindingProxy();
		}
		#endregion
		#region " Data "
		// Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
		public object Data
		{
			get { return (object)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		#endregion
	}

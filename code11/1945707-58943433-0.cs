	public class Collection : BindableObject
	{
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create("Items", typeof(ObservableCollection<People>), typeof(Collection), null, BindingMode.TwoWay, null, null);
		public ObservableCollection<People> Items
		{
			get { return (ObservableCollection<People>)GetValue(ItemsProperty); }
			set { this.SetValue(ItemsProperty, value); }
		} = new ObservableCollection<People>();
	} 

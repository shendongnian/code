		public static readonly DependencyProperty EntityProperty = DependencyProperty.Register("Entity",
	typeof(Entity), typeof(UserEntityControl), new PropertyMetadata(null, EntityPropertyChanged));
		static void EntityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var myCustomControl = d as UserEntityControl;
			var entity = myCustomControl.Entity; // etc...
		}
		public Entity Entity
		{
			get
			{
				return (Entity)GetValue(EntityProperty);
			}
			set
			{
				SetValue(EntityProperty, value);
			}
		}

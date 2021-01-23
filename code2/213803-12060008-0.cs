            /// <summary>
        /// Bubbles up property changed events from a child viewmodel that implements {INotifyPropertyChanged} to the parent keeping
        /// the naming hierarchy in place.
        /// This is useful for nested view models. 
        /// </summary>
        /// <param name="property">Child property that is a viewmodel implementing INotifyPropertyChanged.</param>
        /// <returns></returns>
		public IDisposable BubblePropertyChanged(Expression<Func<INotifyPropertyChanged>> property)
		{
            // This step is relatively expensive but only called once during setup.
			MemberExpression body = (MemberExpression)property.Body;
			var prefix = body.Member.Name + ".";
			INotifyPropertyChanged child = property.Compile().Invoke();
			PropertyChangedEventHandler handler = (sender, e) =>
			{
				this.NotifyPropertyChanged(prefix + e.PropertyName);
			};
			child.PropertyChanged += handler;
			return Disposable.Create(() => { child.PropertyChanged -= handler; });
		}

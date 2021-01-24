		public object Value
		{
			get => _value;
			set
			{
				if (_value == value)
					return;
				if (_value is INotifyPropertyChanged npc)
					npc.PropertyChanged -= OnItemPropertyChanged;
				_value = value;
				RaisePropertyChanged();
				npc = _value as INotifyPropertyChanged;
				if (npc != null)
					npc.PropertyChanged += OnItemPropertyChanged;
				IsDirty = true;
				RaisePropertyChanged(nameof(IsValid));
			}
		}
		private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			RaisePropertyChanged(nameof(Value));
		}

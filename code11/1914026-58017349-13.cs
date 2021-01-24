		public ParameterViewModel(
			string objectName,
			string method,
			string name,
			Type type,
			object value,
			bool isNameReadonly = false) : this(findContext)
		{
			if (string.IsNullOrEmpty(objectName))
				throw new ArgumentNullException(nameof(objectName));
			if (string.IsNullOrEmpty(method))
				throw new ArgumentNullException(nameof(method));
			_name = name ?? throw new ArgumentException(nameof(name));
			_type = type ?? throw new ArgumentNullException(nameof(type));
			_elementType = _type.GetElementType() ?? _type;
			_value = value;
			if (_value != null && _type.IsArray && ((Array)_value).Length > 0)
				LoadItems(_value, _elementType);
			RaisePropertyChanged(nameof(IsValid));
		}

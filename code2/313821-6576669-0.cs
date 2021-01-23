    private string _$name$;
	public string $name$
		{
			get
			{
				return _$name$;
			}
			set
			{
				if (_$name$ != value)
				{
					_$name$ = value;
					RaisePropertyChanged(() => $name$);
				}
			}
		}

	class Foo
	{ 
		private short[] _backingStore = new short[10];
		
		public IndexedProperty<short, short> MyProperty
		{ 
			get
			{
				return new IndexedProperty<short,short>
				(
					getter: key => 
					{
                        //Getter logic goes here. Example:
					    return _backingStore[key];	
					},
					setter: (key, val) =>
					{
                        //Setter logic goes here. Example:
						_backingStore[key] = val;
					}
				);
			}
        }
	}

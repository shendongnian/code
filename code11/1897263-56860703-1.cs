	class Foo
	{ 
		private short[] _backingStore = new short[10];
		
		public IndexedProperty<short, short> MyProperty
		{ 
			get
			{
				return new IndexedProperty<short,short>
				(
					key => 
					{
                        //Getter logic goes here. Example:
					    return _backingStore[key];	
					},
					(key, val) =>
					{
                        //Setter logic goes here. Example:
						_backingStore[key] = val;
					}
				);
			}
        }
	}

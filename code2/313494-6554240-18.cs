		class Person
		{
			public int Age
			{
				get { ... }
				set
				{
					if (value < 0) //'value' is what the user provided
					{ throw new ArgumentOutOfRangeException(); } //Check validity
					this._age = value;
				}
			}
		}
	

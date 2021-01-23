		//field
		private int _dependOne;
		//property
		public int DependOne
		{
			get { return _dependOne; }
			set {
				_dependOne = value;
				Count += value;
			}
		}
		//Finally, use the property instead of the field
		//dependOne = dependOne + 2;
		DependOne += 2;

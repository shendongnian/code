    public class SampleModel : ObservableObject
	{
		private bool? _isFirstChecked;
		public bool? IsFirstChecked
		{
			get
			{
				return this._isFirstChecked;
			}
			set
			{
				if (this._isFirstChecked != value)
				{
					this._isFirstChecked = value;
					this.OnPropertyChanged("IsFirstChecked");
				}
			}
		}
		private int _maxWeight;
		public int MaxWeight
		{
			get 
			{
				return this._maxWeight;
			}
			set 
			{
				if (this._maxWeight != value)
				{
					this._maxWeight = value;
					this.OnPropertyChanged("MaxWeight");
				}
			}
		}
		public IEnumerable<int> ComboBoxItems
		{
			get
			{
				yield return 123;
				yield return 567;
				yield return 999;
				yield return 567;
				yield return 1999;
				yield return 5767;
				yield return 9990;
			}
		}
	}

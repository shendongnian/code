	public class CountryViewModel : ViewModelBase
	{
	    public Country Model {get; set;}
		public string Name
		{
			get => this.Model.Name;
			set
			{
				if (value != this.Model.Name)
				{
					this.Model.Name = value;
					RaisePropertyChanged(() => this.Name);
				}
			}
		}
	}

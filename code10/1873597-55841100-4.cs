	public class DinnerParty
	{
		private int _numberOfPeople;
		private bool _fancyDecorations;
		private bool _healthyOption;
	
		public int CostOfFoodPerPerson { get; } = 25;
	
		public int NumberOfPeople
		{
			get => _numberOfPeople;
			set
			{
				_numberOfPeople = value;
				this.CostUpdated?.Invoke(this, new EventArgs());
			}
		}
	
		public bool FancyDecorations
		{
			get => _fancyDecorations;
			set
			{
				_fancyDecorations = value;
				this.CostUpdated?.Invoke(this, new EventArgs());
			}
		}
	
		public bool HealthyOption
		{
			get => _healthyOption;
			set
			{
				_healthyOption = value;
				this.CostUpdated?.Invoke(this, new EventArgs());
			}
		}
	
		public event EventHandler CostUpdated;
	
		public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
		{
			this._numberOfPeople = numberOfPeople;
			this._healthyOption = healthyOption;
			this._fancyDecorations = fancyDecorations;
		}
	
		public decimal Cost
		{
			get
			{
				decimal decorations = CalculateDecorations(_fancyDecorations);
				decimal costOfBeveragesPerPerson = CalculateCostOfBeveragesPerPerson(_healthyOption);
				decimal costPerPerson = costOfBeveragesPerPerson + this.CostOfFoodPerPerson;
				decimal totalcost = costPerPerson * _numberOfPeople + decorations;
	
				if (_healthyOption)
				{
					totalcost *= .95M;
				}
	
				return totalcost;
			}
		}
	
		private decimal CalculateDecorations(bool fancy)
		{
			decimal per = _fancyDecorations ? 15m : 7.5m;
			decimal flat = _fancyDecorations ? 50m : 30m;
			return _numberOfPeople * per + flat;
		}
	
		private decimal CalculateCostOfBeveragesPerPerson(bool Health)
			=> _healthyOption ? 5m : 20m;
	}

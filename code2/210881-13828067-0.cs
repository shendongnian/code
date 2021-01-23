	public class MoneyJsonConverter : JavaScriptConverter
	{
		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			if (dictionary == null)
				throw new ArgumentNullException("dictionary");
			if (type != typeof(Money))
				return null;
			var amount = Convert.ToDecimal(dictionary.TryGet("Amount"));
			var currency = (string)dictionary.TryGet("Currency");
			return new Money(currency, amount);
		}
		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			var moneyAmount = obj as Money;
			if (moneyAmount == null)
				return new Dictionary<string, object>();
			var result = new Dictionary<string, object>
				{
					{ "Amount", moneyAmount.Amount },
					{ "Currency", moneyAmount.Currency },
				};
			return result;
		}
		public override IEnumerable<Type> SupportedTypes
		{
			get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(Money) })); }
		}
	}

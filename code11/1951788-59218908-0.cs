		public class RatesList : IEnumerable<RateDetail>
		{
			public RatesList(IEnumerable<RatesInput> ratesInputList)
			{
				RatesInputList = ratesInputList;
			}
			private readonly IEnumerable<RatesInput> RatesInputList;
			public IEnumerator<RateDetail> GetEnumerator()
			{
				foreach (var ratesInput in RatesInputList)
				{
					yield return new RateDetail
					{
						RateType = ratesInput.Type1,
						Break = Convert.ToDecimal(ratesInput.Break1, new CultureInfo("en-US")),
						Basic = Convert.ToDecimal(ratesInput.Basic1, new CultureInfo("en-US")),
						Rate = Convert.ToDecimal(ratesInput.Rate1, new CultureInfo("en-US"))
					};
					yield return new RateDetail
					{
						RateType = ratesInput.Type2,
						Break = Convert.ToDecimal(ratesInput.Break2),
						Basic = Convert.ToDecimal(ratesInput.Basic2),
						Rate = Convert.ToDecimal(ratesInput.Rate2, new CultureInfo("en-US"))
					};
					yield return new RateDetail
					{
						RateType = ratesInput.Type3,
						Break = Convert.ToDecimal(ratesInput.Break3),
						Basic = Convert.ToDecimal(ratesInput.Basic3),
						Rate = Convert.ToDecimal(ratesInput.Rate3, new CultureInfo("en-US"))
					};
				}
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

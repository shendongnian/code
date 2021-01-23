	public static List<string> PaymentCurrency = new List<string> { "USD", "GBP", "EUR", "AUD", "BRL", "CAD", "CHF", "CLP", "CNY", "CZK", "DKK", "FJD", "HKD", "HNL", "HUF", "IDR", "ILS", "INR", "ISK", "JPY", "KRW", "LVL", "MXN", "MYR", "NOK", "NZD", "PHP", "PKR", "PLN", "RUB", "SEK", "SGD", "THB", "TRY", "TWD", "ZAR" };
	List<SelectListItem> PaymentCurrencyOptionItems = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
		PaymentCurrencyOptionItems.AddRange(Lolio.PaymentCurrency.Select(r => new SelectListItem { Text = r+" "+LangResources.Get("Currency_" + r), Value = r }));
	IEnumerable<SelectListItem> LinkPaymentType = new SelectList(PaymentTypeOptionItems, "Value", "Text", lnk.Performance.PaymentType);
	Html.DropDownListFor(m => m.PaymentType, LinkPaymentType))

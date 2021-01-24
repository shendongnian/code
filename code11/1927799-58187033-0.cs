c#
List<ProductPricingGetDataItem> grouped = productInformationItems.GroupBy(
										p => p.ProductID,
										(key, g) => new ProductPricingGetDataItem() { ProductID = key, Terms = g.Select(x => new Terms(x.BillingPeriodName, x.PriceAmount)).ToList() }).ToList();
In order for that code to work, you need to add a constructor to `Terms` :
c#
public Terms(string term, decimal price)
{
	Term = term;
	Price = price;
}
Fiddle with working example : https://dotnetfiddle.net/EE2BpP

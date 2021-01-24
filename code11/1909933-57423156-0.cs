void Main()
{
	var purchases = new List<Purchase>() {
		new Purchase() { BrandName = "A", CostOfItem = 1.13M, Day = 1, TotalPurchased = 125 },
		new Purchase() { BrandName = "B", CostOfItem = 1.52M, Day = 1, TotalPurchased = 165 },
		new Purchase() { BrandName = "C", CostOfItem = 1.90M, Day = 1, TotalPurchased = 836 },
		new Purchase() { BrandName = "A", CostOfItem = 1.74M, Day = 2, TotalPurchased = 583 },
		//new Purchase() { BrandName = "B", CostOfItem = 1.52M, Day = 2, TotalPurchased = 785 },
		new Purchase() { BrandName = "C", CostOfItem = 1.42M, Day = 2, TotalPurchased = 369 },
		new Purchase() { BrandName = "A", CostOfItem = 1.93M, Day = 3, TotalPurchased = 789 },
		new Purchase() { BrandName = "B", CostOfItem = 1.87M, Day = 3, TotalPurchased = 739 },
		new Purchase() { BrandName = "C", CostOfItem = 1.78M, Day = 3, TotalPurchased = 436 },
	};
	var results = from day in purchases.Select(x => x.Day).Distinct()
				  from brand in purchases.Select(x => x.BrandName).Distinct()
				  join purchase in purchases on new { Brand = brand, Day = day } equals new { Brand = purchase.BrandName, Day = purchase.Day } into j
				  from result in j.DefaultIfEmpty(new Purchase() { BrandName = brand, Day = day, TotalPurchased = 0, CostOfItem = 0 })
				  select new BrandsProfit()
				  {
					  BrandName = result.BrandName,
					  Day = result.Day,
					  TotalDailyProfit = result.TotalPurchased * result.CostOfItem
				  };
	Debug.WriteLine(JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented));
}
class Purchase
{
	public string BrandName { get; set; }
	public int Day { get; set; }
	public int TotalPurchased { get; set; }
	public decimal CostOfItem { get; set; }
}
class BrandsProfit
{
	public string BrandName { get; set; }
	public int Day { get; set; }
	public decimal TotalDailyProfit { get; set; }
}
Produces the following result:-
[
  {
    "BrandName": "A",
    "Day": 1,
    "TotalDailyProfit": 141.25
  },
  {
    "BrandName": "B",
    "Day": 1,
    "TotalDailyProfit": 250.80
  },
  {
    "BrandName": "C",
    "Day": 1,
    "TotalDailyProfit": 1588.40
  },
  {
    "BrandName": "A",
    "Day": 2,
    "TotalDailyProfit": 1014.42
  },
  {
    "BrandName": "B",
    "Day": 2,
    "TotalDailyProfit": 0.0
  },
  {
    "BrandName": "C",
    "Day": 2,
    "TotalDailyProfit": 523.98
  },
  {
    "BrandName": "A",
    "Day": 3,
    "TotalDailyProfit": 1522.77
  },
  {
    "BrandName": "B",
    "Day": 3,
    "TotalDailyProfit": 1381.93
  },
  {
    "BrandName": "C",
    "Day": 3,
    "TotalDailyProfit": 776.08
  }
]
If you didn't want to go down the road of using the example above, you could consider updating the source query you use to generate the data in your `purchaseQuery` to use an outer join like the one above... that way you would have a row for every combination of brand/day, even if a brand never sold on a particular day.

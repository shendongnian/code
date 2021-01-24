    var dictionary = new Dictionary<int, List<Terms>>();
	foreach (ProductTermAndPricingDataItem item in productInformationItems)
	{
	            if(dictionary.ContainsKey(item.ProductID))
	            {
	            	dictionary[item.ProductID].Add(new Terms { Term = item.BillingPeriodName, Price = item.PriceAmount});
	            }
	            else
	            {
	            	dictionary.Add(item.ProductID, new List<Terms>() { new Terms() {Term = item.BillingPeriodName, Price = item.PriceAmount         	} });
	            }  
     }

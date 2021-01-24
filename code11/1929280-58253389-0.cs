csharp
using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("{");
		sb.Append("   \"items\": [");
		sb.Append("        {");
		sb.Append("            \"product\": \"desktop-licence\",");
		sb.Append("            \"quantity\": 1,");
		sb.Append("            \"display\": \"Desktop Licence\",");
		sb.Append("            \"sku\": \"DTQ-P\",");
		sb.Append("            \"subtotal\": 46.32,");
		sb.Append("            \"subtotalDisplay\": \"$46.32 AUD\",");
		sb.Append("            \"subtotalInPayoutCurrency\": 30.08,");
		sb.Append("            \"subtotalInPayoutCurrencyDisplay\": \"USD 30.08\",");
		sb.Append("            \"discount\": 0.0,");
		sb.Append("            \"discountDisplay\": \"$0.00 AUD\",");
		sb.Append("            \"discountInPayoutCurrency\": 0.0,");
		sb.Append("            \"discountInPayoutCurrencyDisplay\": \"USD 0.00\",");
		sb.Append("            \"fulfillments\": {");
		sb.Append("            \"fulfillmentItem\": [");
		sb.Append("                {");
		sb.Append("                \"license\": \"\\\"BHFU-FK95-SQLF-JCG7-9NAY-969H-98\\\"\",");
		sb.Append("                \"display\": \"License Key\",");
		sb.Append("                \"type\": \"license\"");
		sb.Append("                }");
		sb.Append("           ]");
		sb.Append("      }");
		sb.Append("  }");
		sb.Append(" ]");
		sb.Append("}");
		// Parse normal properties.
		var oItem = JsonConvert.DeserializeObject<Item>(sb.ToString());
		
		// Custom name.
		string customAttrName = "fulfillmentItem";
		
		// Parse custom fufillments array.
		var jsonObj = JObject.Parse(sb.ToString());
		
		// Init.
		oItem.fulfillments = new Fulfillments();
		oItem.fulfillments.fulfillmentItem = new List<FulfillmentItem>();
		
		// Get data using JToken. << use some for loop if multiple fulfillments...
		string licence = (string)jsonObj.SelectToken("items[0].fulfillments." + customAttrName + "[0].license");
		string display = (string)jsonObj.SelectToken("items[0].fulfillments." + customAttrName + "[0].display");
		string type = (string)jsonObj.SelectToken("items[0].fulfillments." + customAttrName + "[0].type");
		
		oItem.fulfillments.fulfillmentItem.Add(new FulfillmentItem() {
		    license = licence,
			display = display,
			type = type
		});
		
		// Check values.
		foreach (var itm in oItem.fulfillments.fulfillmentItem)
		{
			Console.WriteLine(itm.license);
			Console.WriteLine(itm.display);
		}
		
		// return oItem;
	}
}
public partial class Item
{
    public string product { get; set; }
    public long quantity { get; set; }
    public string sisplay { get; set; }
    public string sku { get; set; }
    public double subtotal { get; set; }
    public string subtotalDisplay { get; set; }
    public double subtotalInPayoutCurrency { get; set; }
    public string subtotalInPayoutCurrencyDisplay { get; set; }
    public long discount { get; set; }
    public string discountDisplay { get; set; }
    public long discountInPayoutCurrency { get; set; }
    public string discountInPayoutCurrencyDisplay { get; set; }
    public Fulfillments fulfillments { get; set; }
}
public partial class Fulfillments
{
    public List<FulfillmentItem> fulfillmentItem { get; set; }
}
public partial class FulfillmentItem
{
    public string license { get; set; }
    public string display { get; set; }
    public string type { get; set; }
}

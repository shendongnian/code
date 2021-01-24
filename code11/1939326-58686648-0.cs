C#
public async Task<IActionResult> SomeAction(Guid id)
{
    var products = ..;
	foreach (var item in products)
	{
		p.UnitID = await GetUnit(item.UnitID);
	}
    return View(products);
}
private async Task<string> GetUnit(Guid id)
{
    string a = "https://localhost:5001/api/Units/";
    a += id.ToString();
    var temp = await Http.GetJsonAsync<Unit>(a); //it fails here
    return temp.Name;
}
public class Product 
{
	public string Name { get; set; }	
	public decimal Amount { get; set; }	
	public string UnitID { get; set; }	
	public string PriceNetto { get; set; }	
}

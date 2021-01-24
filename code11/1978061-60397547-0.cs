public class Purchase 
{
    public int StoreId { get; set; }
    [ForeignKey("StoreId")]
    public Store Store { get; set;}
}
I'd pass a model to the view similar to below. IMO, it's cleaner than using ViewBag.
public class CreatePurchaseModel
{
    //To populate a list
    public List<Store> AvailableStores { get; set; }
    //The actual object to be created
    public Purchase Purchase { get; set; }
}
Controller Method:
// GET: Purchases/Create
public ActionResult Create()
{
    var vm = new CreatePurchaseModel() 
    {
        AvailableStores = db.Stores.ToList(),
        Purchase = new Purchase()
    };
    return View(vm);     
}
Populate a dropdownlist with the AvailableStores property to set the Purchase.StoreId
@Html.DropDownListFor(m => m.Purchase.StoreId, Model.AvailableStores.Select(x => new SelectListItem { Text = x.StoreName.ToString(), Value = x.StoreId.ToString() }))
If it's setup properly, all you need in the post method parameters is the purchase
[ValidateAntiForgeryToken, HttpPost]
public ActionResult Create(Purchase purchase) 
{
    //purchase.StoreId should have a non zero value
    db.Purchases.Add(purchase);
    db.SaveChanges();
}

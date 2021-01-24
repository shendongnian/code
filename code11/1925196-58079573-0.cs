public ActionResult CreateOrUpdate(int? id)
{
     var model = MyViewModel();
     if (id.HasValue && id.Value != default)
     {
          model = GetFromDatabase(id.Value);
     }
     ViewBag.Products = GetAllProductsFromDatabase()
                       .Select(x => new SelectListItem()
                       {
                            Text = x.FullName,
                            Value = x.Id.ToString(),
                            Selected=x.ProductId==model?.ProductId
                       }).ToList();
     return View(model);
}
<div>
     <label asp-for="ProductId"></label>
     <select asp-for="ProductId" asp-items="@ViewBag.Products</select>
</div>

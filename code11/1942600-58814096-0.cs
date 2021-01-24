c#
 app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: null,
                pattern: "{category}/Page{productPage:int}",
                defaults: new { controller = "Product", action = "List" }
            );
            endpoints.MapControllerRoute(
                name: null,
                pattern: "Page{productPage:int}",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    productPage = 1
                }
                 ...
            );
// And my default:
            endpoints.MapControllerRoute("default", "{controller=Product}/{action=List}/{id?}");
This is a form for one of my projects:
cshtml
<form asp-action="Delete" method="post">
                    <a asp-action="Edit" class="btn btn-sm btn-warning"
                       asp-route-productId="@item.ProductID">
                        Edit
                    </a>
                    <input type="hidden" name="ProductID" value="@item.ProductID" />
                    <button type="submit" class="btn btn-danger btn-sm">
                        Delete
                    </button>
                </form>
There´s a difference here:
Mine:
asp-route-productId="@item.ProductID"
Yours:
asp-route-id="@Model.Id"
How did you call it?
This is my Edit method:
c#
 [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} ha sido borrado";
            }
            return RedirectToAction("Index");
        }
    }
And the last call:
c#
public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productID);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
You can try to:
Change to IActionResult instead RedirectToActionResult .

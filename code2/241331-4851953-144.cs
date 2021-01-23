    public class ProductController : Controller
    {
        private readonly IProductService service;
    
        public ProductController(IProductService service) => this.service = service;
    
        public ActionResult Create(
            [Bind(Exclude = "Id")] Product productToCreate)
        {
            try
            {
                this.service.CreateProduct(productToCreate);
            }
            catch (ValidationException ex)
            {
                this.ModelState.AddModelErrors(ex);
                return View();
            }
            
            return RedirectToAction("Index");
        }
    }
    public static class MvcValidationExtension
    {
        public static void AddModelErrors(
            this ModelStateDictionary state, ValidationException exception)
        {
            foreach (var error in exception.Errors)
            {
                state.AddModelError(error.Key, error.Message);
            }
        }
    }

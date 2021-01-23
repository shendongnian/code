    public class ProductModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var price = bindingContext.ValueProvider.GetValue("unitprice");
            if (price != null)
            {
                decimal p;
                if (decimal.TryParse(price.AttemptedValue, NumberStyles.Currency, null, out p))
                {
                    return new Product
                    {
                        UnitPrice = p
                    };
                }
                else
                {
                    // The user didn't type a correct price => insult him
                    bindingContext.ModelState.AddModelError("UnitPrice", "Invalid price");
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }

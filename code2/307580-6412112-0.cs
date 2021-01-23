    public class DateTimeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // ... Your code here
    
            return base.BindModel(controllerContext, bindingContext);
        }
    
    }

    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) 
    { 
        //... code here 
        controllerContext.HttpContext.Request.Unvalidated.Form.GetValues(key); 
        //... code here 
    }

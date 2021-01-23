        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(YourType))
            {
                 // load YourType from DB
                 return instanceOfYourType;
            }            
            throw new InvalidOperationException("Supports only YourType objects");
        }

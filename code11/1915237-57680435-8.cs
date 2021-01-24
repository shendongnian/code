    public class NullByteArrayModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            if(bindingContext.ModelType == typeof(byte[])) {
                return base.BindModel(controllerContext, bindingContext) ?? new byte[0];
            }
    
            return base.BindModel(controllerContext, bindingContext);
        }
    }

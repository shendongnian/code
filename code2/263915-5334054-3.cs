    public class PostModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Post))
            {
                try
                {
                    // Create Post
                    return base.BindModel(controllerContext, bindingContext);
                }
                catch (InvariantException ie)
                {
                    // If invalid, add errors from factory to ModelState
                    bindingContext.ModelState.AddNewErrors(ie.ModelState);
                    bindingContext.ModelState.AddValuesFor<Post>(bindingContext.ValueProvider);
                    return ie.FailingObject;
                }
            }

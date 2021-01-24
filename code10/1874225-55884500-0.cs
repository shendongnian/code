    public class EmptyCollectionModelBinder : CollectionModelBinder<FilterType>
    {
        public EmptyCollectionModelBinder(IModelBinder elementBinder) : base(elementBinder)
        {
        }
        public override async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await base.BindModelAsync(bindingContext);
            //removing validation only for this collection
            bindingContext.ModelState.ClearValidationState(bindingContext.ModelName);
        }
    }

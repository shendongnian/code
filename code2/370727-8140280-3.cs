    public class MyDataAnnotationsModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        private bool _provideParentValidators = false;
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            if (metadata.ContainerType != null && metadata.ContainerType.Name.IndexOf("Changeable") > -1 && metadata.PropertyName == "Value")
            {
                var viewContext = context as ViewContext;
                if (viewContext != null)
                {
                    var viewData = viewContext.ViewData;
                    var index = viewData.Keys.ToList().IndexOf("Value");
                    var parentMetadata = viewData.Values.ToList()[index] as ModelMetadata;
                    _provideParentValidators = true;
                    var vals = base.GetValidators(parentMetadata, context);
                    _provideParentValidators = false;
                    return vals;
                }
                else
                {
                    var viewData = context.Controller.ViewData;
                    var keyName = viewData.ModelState.Keys.ToList().Last().Split(new string[] { "." }, StringSplitOptions.None).First();
                    var index = viewData.Keys.ToList().IndexOf(keyName);
                    var parentMetadata = viewData.Values.ToList()[index] as ModelMetadata;
                    parentMetadata.Model = metadata.Model;
                    _provideParentValidators = true;
                    var vals = base.GetValidators(parentMetadata, context);
                    _provideParentValidators = false;
                    return vals;
                }
            }
            else if (metadata.ModelType.Name.IndexOf("Changeable") > -1 && !_provideParentValidators)
            {
                // DO NOT provide parent's validators, unless it is at the request of the child Value property
                return new List<ModelValidator>();
            }
            return base.GetValidators(metadata, context, attributes).ToList();
        }
    }

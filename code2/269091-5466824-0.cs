    public class OrderModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(
			ControllerContext controllerContext,
			ModelBindingContext bindingContext,
			Type modelType)
        {
			// get the parameter OrderTypeId
			ValueProviderResult result;
			result = bindingContext.ValueProvider.GetValue("OrderTypeId");
			// I'm assuming 1 for Bottling, 2 for Finishing
			if (result.AttemptedValue.Equals("1"))
				return base.CreateModel(controllerContext,
						bindingContext,
						typeof(OrderBottling));
			else if (result.AttemptedValue.Equals("2"))
				return base.CreateModel(controllerContext,
						bindingContext,
						typeof(OrderFinishing));
			return null; // need to specify OrderTypeId
        }
	}

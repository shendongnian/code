			public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
			{
				Object o = base.BindModel(controllerContext, bindingContext);
				string ratingKey = bindingContext.ModelName + ".Rating";            
				PersonRating pr = (PersonRating)o;
				ValueProviderResult ratingVpr = controllerContext.
											Controller.
												ValueProvider.
													GetValue(ratingKey);
				String ratingVal = ratingVpr.AttemptedValue;
				String ratingErrorMessage = getRatingModelErrorMessage(
												ratingKey,
												ratingVal,
												pr);
				
				if (!String.IsNullOrEmpty(ratingErrorMessage))
				{
					bindingContext.ModelState[ratingKey].Errors.Clear();
					bindingContext.ModelState.AddModelError(ratingKey, ratingErrorMessage);
				}
				return o;
                             }

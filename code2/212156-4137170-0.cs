    public class ClientsideValidationBehavior<T> : IBehavior<IMemberElement> where T : class
    {
    	private readonly FluentViewPage<T> _viewPage;
    
    	public ClientsideValidationBehavior(FluentViewPage<T> viewPage)
    	{
    		_viewPage = viewPage;
    	}
    
    	public void Execute(IMemberElement element)
    	{
    		var attribute = element.GetAttribute<ValidationAttribute>();
    
    		if (attribute == null)
    		{
    			return;
    		}
    
    		var formContext = _viewPage.ViewContext.FormContext;
    		var fieldMetadata = formContext.GetValidationMetadataForField(UiNameHelper.BuildNameFrom(element.ForMember), true);
    
    		var modelMetadata = ModelMetadata.FromStringExpression(element.ForMember.Member.Name, _viewPage.ViewData);
    		var validators = ModelValidatorProviders.Providers.GetValidators(modelMetadata, _viewPage.ViewContext);
    
    		validators.SelectMany(v => v.GetClientValidationRules()).ForEach(fieldMetadata.ValidationRules.Add);
    
    		fieldMetadata.ValidationMessageId = element.ForMember.Member.Name + "_Label";
    	}
    }

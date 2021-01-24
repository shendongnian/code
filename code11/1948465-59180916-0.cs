    public class CustomValidationHtmlAttributeProvider : DefaultValidationHtmlAttributeProvider
    {
        private readonly IOptions<MvcViewOptions> _optionsAccessor;
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly ClientValidatorCache _clientValidatorCache;
    
    
        public CustomValidationHtmlAttributeProvider(IOptions<MvcViewOptions> optionsAccessor, IModelMetadataProvider metadataProvider, ClientValidatorCache clientValidatorCache) 
            : base(optionsAccessor, metadataProvider, clientValidatorCache)
        {
            _optionsAccessor = optionsAccessor;
            _metadataProvider = metadataProvider;
            _clientValidatorCache = clientValidatorCache;
        }
    
        public override void AddValidationAttributes(ViewContext viewContext, ModelExplorer modelExplorer, string expression, IDictionary<string, string> attributes)
        {
            // getting existing validation attribute
            var greaterThanAttribute = modelExplorer.Metadata.ValidatorMetadata.FirstOrDefault(x =>
                x.GetType() == typeof(GreaterThanAttribute)) as GreaterThanAttribute;
            var otherPropertyName = greaterThanAttribute.OtherPropertyName;
    
            var targetExpression = GetTargetPropertyExpression(expression, otherPropertyName);
            var otherValue = GetValueOnExpression(modelExplorer.Container.Model, targetExpression);
    
            greaterThanAttribute.OtherPropertyValue = otherValue;
    
            base.AddValidationAttributes(viewContext, modelExplorer, attributes);
        }
    	
    	private static object GetValueOnExpression(object container, string expression)
    	{
    		while (expression != "")
    		{
    			if (NextStatementIsIndexer(expression))
    			{
    				var index = GetIndex(expression);
    
    				switch (container)
    				{
    					case IDictionary dictionary:
    						container = dictionary[index];
    						break;
    					case IEnumerable<object> enumerable:
    						container = enumerable.ElementAt(int.Parse(index));
    						break;
    					default:
    						throw new Exception($"{container} is unknown collection type");
    				}
    
    				expression = ClearIndexerStatement(expression);
    			}
    			else
    			{
    				var propertyName = GetPropertyStatement(expression);
    				var propertyInfo = container.GetType().GetProperty(propertyName);
    				if (propertyInfo == null)
    					throw new Exception($"Can't find {propertyName} property in the container {container}");
    
    				container = propertyInfo.GetValue(container);
    				expression = ClearPropertyStatement(expression);
    			}
    		}
    
    		return container;
    	}
    
    	private static bool NextStatementIsIndexer(string expression) 
    		=> expression[0] == '[';
    
    	private static string ClearPropertyStatement(string expression)
    	{
    		var statementEndPosition = expression.IndexOfAny(new [] {'.', '['});
    		if (statementEndPosition == -1) return "";
    		if (expression[statementEndPosition] == '.') statementEndPosition++;
    		return expression.Substring(statementEndPosition);
    	}
    
    	private static string GetPropertyStatement(string expression)
    	{
    		var statementEndPosition = expression.IndexOfAny(new [] {'.', '['});
    		if (statementEndPosition == -1) return expression;
    		return expression.Substring(0, statementEndPosition);
    	}
    
    	private static string ClearIndexerStatement(string expression)
    	{
    		var statementEndPosition = expression.IndexOf(']');
    		if (statementEndPosition == expression.Length - 1) return "";
    		if (expression[statementEndPosition + 1] == '.') statementEndPosition++;
    		return expression.Substring(statementEndPosition + 1);
    	}
    
    	private static string GetIndex(string expression)
    	{
    		var closeBracketPosition = expression.IndexOf(']');
    		return expression.Substring(1, closeBracketPosition - 1);
    	}
    
    	private static string GetTargetPropertyExpression(string sourceExpression, string targetProperty)
    	{
    		var memberAccessTokenPosition = sourceExpression.LastIndexOf('.');
    		if (memberAccessTokenPosition == -1) // expression is just a property name
    			return targetProperty;
    		var newExpression = sourceExpression.Substring(0, memberAccessTokenPosition + 1) + targetProperty;
    		return newExpression;
    	}
    }

	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	//using my models
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
	using Microsoft.Extensions.Logging;
	namespace Mynamespaceforthewebproject
	{
		public class AliasModelBinder : ComplexTypeModelBinder
		{
			public AliasModelBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders, ILoggerFactory loggerFactory)
				: base(propertyBinders, loggerFactory)
			{
			}
			protected override Task BindProperty(ModelBindingContext bindingContext)
			{
				var containerType = bindingContext.ModelMetadata.ContainerType;
				if (containerType != null)
				{
					var propertyType = containerType.GetProperty(bindingContext.ModelMetadata.PropertyName);
					var attributes = propertyType.GetCustomAttributes(true);
					var aliasAttribute = attributes.SingleOrDefault(attr => attr is BindingAliasAttribute) as BindingAliasAttribute;
					if (aliasAttribute != null)
					{
						bindingContext.ValueProvider = new AliasValueProvider(bindingContext.ValueProvider,
							new Alias {OriginalPropertyName = bindingContext.ModelName, AliasName = aliasAttribute.Alias});
					}
				}
				return base.BindProperty(bindingContext);
			}
		}
		public class AliasValueProvider : IValueProvider
		{
			private readonly IValueProvider _provider;
			private readonly Alias _alias;
			public AliasValueProvider(IValueProvider provider, Alias alias)
			{
				_provider = provider;
				_alias = alias;
			}
			public bool ContainsPrefix(string prefix)
			{
				if (prefix == _alias.OriginalPropertyName)
				{
					return _provider.ContainsPrefix(_alias.OriginalPropertyName) ||
						   _provider.ContainsPrefix(_alias.AliasName);
				}
				return _provider.ContainsPrefix(prefix);
			}
			public ValueProviderResult GetValue(string key)
			{
				if (key == _alias.OriginalPropertyName)
				{
					var original = _provider.GetValue(_alias.OriginalPropertyName);
					return original.Values.Any() ? original : _provider.GetValue(_alias.AliasName);
				}
				return _provider.GetValue(key);
			}
		}
		public class Alias
		{
			public string OriginalPropertyName { get; set; }
			public string AliasName { get; set; }
		}
		public class AliasModelBinderProvider<T> : IModelBinderProvider
		{
			public IModelBinder GetBinder(ModelBinderProviderContext context)
			{
				if (context.Metadata.ModelType == typeof(T))
				{
					var propertyBinders = new Dictionary<ModelMetadata, IModelBinder>();
					for (var i = 0; i < context.Metadata.Properties.Count; i++)
					{
						var property = context.Metadata.Properties[i];
						propertyBinders.Add(property, context.CreateBinder(property));
					}
					return new AliasModelBinder(propertyBinders,
						(ILoggerFactory)context.Services.GetService(typeof(ILoggerFactory)));
				}
				return null;
			}
		}
	}

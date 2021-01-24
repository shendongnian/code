	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using Microsoft.Extensions.Primitives;
	namespace MYDOMAIN.Web.AliasModelBinder
	{
		public class AliasValueProvider : IValueProvider
		{
			private readonly IValueProvider _provider;
			private readonly string _originalName;
			private readonly string[] _allNamesToBind;
			public AliasValueProvider(IValueProvider provider, string originalName, IEnumerable<string> aliases)
			{
				_provider = provider;
				_originalName = originalName;
				_allNamesToBind = new[] {_originalName}.Concat(aliases).ToArray();
			}
			public bool ContainsPrefix(string prefix)
			{
				if (prefix == _originalName)
				{
					return _allNamesToBind.Any(_provider.ContainsPrefix);
				}
				return _provider.ContainsPrefix(prefix);
			}
			public ValueProviderResult GetValue(string key)
			{
				if (key == _originalName)
				{
					var results = _allNamesToBind.Select(alias => _provider.GetValue(alias)).ToArray();
					StringValues values = results.Aggregate(values, (current, r) => StringValues.Concat(current, r.Values));
					return new ValueProviderResult(values, results.First().Culture);
				}
				return _provider.GetValue(key);
			}
		}
	}
		
		

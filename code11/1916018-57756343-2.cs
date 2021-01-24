	async Task Main()
	{
		var html = @"<div itemscope itemtype='http://schema.org/Organization'>
	  <span itemprop='name'>Google.org (GOOG)</span>
	  <div itemprop='address' itemscope itemtype='http://schema.org/PostalAddress'>
	    Main address:
	      <span itemprop='streetAddress'>38 avenue de l'Opera</span>
	      <span itemprop='postalCode'>F-75002</span>
	      <span itemprop='addressLocality'>Paris, France</span>
	  </div>
	    Tel:<span itemprop='telephone'>( 33 1) 42 68 53 00 </span>,
	    Fax:<span itemprop='faxNumber'>( 33 1) 42 68 53 01 </span>,
	    E-mail: <span itemprop='email'>secretariat(at)google.org</span>
	 <span itemprop='alumni' itemscope itemtype='http://schema.org/Person'>
	   <span itemprop='name'>Jack Dan</span>
	 </span>
	 <span itemprop='alumni' itemscope itemtype='http://schema.org/Person'>
	   <span itemprop='name'>John Smith</span>
	 </span>
	</div>";
		var context = BrowsingContext.New();
		var document = await context.OpenAsync(res => res.Content(html));
		var result = Parse(document.QuerySelector("[itemscope]"));
		var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
        json.Dump();
	}
	
	void Populate(IElement element, Dictionary<string, object> result)
	{
		foreach (var child in element.Children)
		{
			var prop = child.GetAttribute("itemprop");
	
			if (prop != null)
			{
				var scope = child.GetAttribute("itemscope");
				var value = default(Object);
	
				if (scope != null)
				{
					value = Parse(child);
				}
				else
				{
					value = child.TextContent;
				}
	
				if (result.TryGetValue(prop, out var item))
				{
					if (item is List<Object> list)
					{
						list.Add(value);
					}
					else
					{
						result[prop] = new List<Object>
						{
							item,
							value
						};
					}
				}
				else
				{
					result[prop] = value;
				}
			}
			else
			{
				Populate(child, result);
			}
		}
	}
	
	Object Parse(IElement element)
	{
		var result = new Dictionary<string, object>();
		result["itemtype"] = element.GetAttribute("itemtype");
		Populate(element, result);
		return result;
	}

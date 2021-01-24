    <div cats-language-key="Home-S2-h1-p1">
    
    </p>
    [HtmlTargetElement("p",Attributes = CatsLanguageKey)]
    [HtmlTargetElement("span", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("a", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("li", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("h1", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("h2", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("h3", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("h4", Attributes = CatsLanguageKey)]
    [HtmlTargetElement("div", Attributes = CatsLanguageKey)]
    public class LanguageTagHelper: TagHelper
    {
    	private const string CatsLanguageKey= "cats-language-key";
    
    	private readonly ILanguageRepository _repository;
    	private readonly ClaimsPrincipal _user;
    	private readonly IMemoryCache _memoryCache;
    
    	public LanguageTagHelper(ILanguageRepository repository, IHttpContextAccessor context, IMemoryCache memoryCache)
    	{
    		_repository = repository;
    		_user = context.HttpContext.User;
    		_memoryCache = memoryCache;
    	}
    
    	[HtmlAttributeName(CatsLanguageKey)]
    	public string Key { get; set; }
    
    
    
    	public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    	{
    		
    		
    
    
    		var childContent = await output.GetChildContentAsync();
    		if (!childContent.IsEmptyOrWhiteSpace)
    		{
    			var textItem = _repository.GetHtml(Key, childContent.GetContent().Trim());
    			if (_user.Identity.IsAuthenticated && _user.IsInRole(MagicStrings.ROLE_TEXTER))
    			{
    				output.Attributes.Add("data-language-target", textItem.Language);
    				output.Attributes.Add("data-language-key", textItem.Key);
    				var html = new HtmlString(textItem.Text);
    				output.Content.SetHtmlContent(html);
    				
    				_memoryCache.Remove(Key);
    			}
    			else
    			{
    				string text = string.Empty;
    				if (!_memoryCache.TryGetValue(Key, out text))
    				{
    					text = Regex.Replace(textItem.Text, @">\s+<", "><", RegexOptions.Compiled | RegexOptions.Multiline);
    					text = Regex.Replace(text, @"<!--(?!\s*(?:\[if [^\]]+]|<!|>))(?:(?!-->)(.|\n))*-->", "", RegexOptions.Compiled | RegexOptions.Multiline);
    					text = Regex.Replace(text, @"^\s+", "", RegexOptions.Compiled | RegexOptions.Multiline);
    					text = Regex.Replace(text, @"\r\n?|\n", "", RegexOptions.Compiled | RegexOptions.Multiline);
    					text = Regex.Replace(text, @"\s+", " ", RegexOptions.Compiled | RegexOptions.Multiline);
    					_memoryCache.Set(Key, text, new MemoryCacheEntryOptions() { Priority= CacheItemPriority.Low, SlidingExpiration= new TimeSpan(hours:1,minutes:0,seconds:0) });
    				}
    				var html = new HtmlString(text);
    				output.Content.SetHtmlContent(html);
    
    			}
    
    
    		}
    	}
    }

	using Microsoft.AspNetCore.Razor.TagHelpers;  
	using System.Collections.Generic;
	using System.Linq;
	namespace CustomTagHelper.TagHelpers  
	{  
		[HtmlTargetElement("my-first-tag-helper")]  
		public class MyCustomTagHelper : TagHelper  
		{  
			public string Id { get; set; }
			public string Type { get; set; }
			public override void Process(TagHelperContext context, TagHelperOutput output)  
			{  
				output.SuppressOutput();
				output.Content.Clear();
				// ------------------- Begin Extra Attributes --------------------
				var attributeObjects = context.AllAttributes.ToList();
				var props = this.GetType().GetProperties().Select(p => p.Name);
				attributeObjects.RemoveAll(a => props.Contains(a.Name));
				var extraAttributeList = new List<string>();
				foreach (var attr in attributeObjects)
				{
					extraAttributeList.Add($"{attr.Name}=\"{attr.Value}\"");
				}                                                                                                 
				// ------------------- End Extra Attributes --------------------
				output.Content.SetHtmlContent($"<input id={Id} type={Type} {string.Join(" ", extraAttributeList)}/>");
			}  
		}  
	}  

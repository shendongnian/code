		public static MvcHtmlString DropDownList(this AjaxHelper html, string action, RouteValueDictionary routeValues, AjaxOptions options, IEnumerable<SelectListItem> selectItems, IDictionary<string, object> listHtmlAttributes)
		{
			var url = new UrlHelper(html.ViewContext.RequestContext);
			// Wrap it in a form
			var formBuilder = new TagBuilder("form");
			//	build the <select> tag
			var listBuilder = new TagBuilder("select");
			if (listHtmlAttributes != null && listHtmlAttributes.Count > 0) listBuilder.MergeAttributes(listHtmlAttributes);
			StringBuilder optionHTML = new StringBuilder();
			foreach (SelectListItem item in selectItems)
			{
				var optionBuilder = new TagBuilder("option");
				optionBuilder.MergeAttribute("value", item.Value);
				optionBuilder.InnerHtml = item.Text;
				if (item.Selected)
				{
					optionBuilder.MergeAttribute("selected", "selected");
				}
				//optionBuilder.Attributes["onchange"] = "($this.form).attr('action', '" + url.Action(action, routeValues).Replace("___", item.Value) + "');$(this.form).submit();";
				optionHTML.Append(optionBuilder.ToString());
			}
			listBuilder.InnerHtml = optionHTML.ToString();
			listBuilder.Attributes["onchange"] = "$(this.form).attr('action', '" + url.Action(action, routeValues).Replace("___", "' + $(this).first('option:selected').val() + '") + "');$(this.form).submit();";
			formBuilder.InnerHtml = listBuilder.ToString();
			foreach (var ajaxOption in options.ToUnobtrusiveHtmlAttributes())
				formBuilder.MergeAttribute(ajaxOption.Key, ajaxOption.Value.ToString());
			string formHtml = formBuilder.ToString(TagRenderMode.Normal);
			return MvcHtmlString.Create(formHtml);
		}
 

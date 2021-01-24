	var dict = new ViewDataDictionary
	{
		{ "ButtonText", "Hello!" }
	};
	dict.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "myForm_" };
	Html.RenderPartial("~/Views/_myPartial1.cshtml", Model, dict);

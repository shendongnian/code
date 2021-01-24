    @inject IHtmlLocalizer<HomeController> HtmlLocalizer
    @{
        var nlHtmlLocalizer = HtmlLocalizer.WithCulture(new System.Globalization.CultureInfo("nl"));
    }
    <li>@nlHtmlLocalizer ["My string 2 <span style=\"font-weight: bold;\">with bold</span>."]</li>

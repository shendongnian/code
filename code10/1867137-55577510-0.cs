public static IHtmlString HrefLangLinks(this PageData currentPage)
{
    // StringBuilder usually performs better than concatenating a variable number of strings.
    var sb = new StringBuilder;
    foreach (string language in currentPage.ExistingLanguages.Select(culture => culture.Name))
    {
        // Get the URL to the page in the individual languages, respecting the
        // website language settings (sometimes a language is bound to another hostname)
        string url = UrlResolver.Current.GetUrl(currentPage.ContentLink, language);
        sb.AppendLine($"<link href=\"{url}\" hreflang=\"{language}\" rel=\"alternate\"/>");
    }
    return new MvcHtmlString(sb.ToString());
}
But I usually implement something like this as a Razor helper.

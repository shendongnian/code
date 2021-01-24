    public static async Task<HtmlString> RenderScriptAsync(this IHtmlHelper htmlHelper, string jsFilePath)
    {
        using (var reader = new StreamReader(jsFilePath))
        {
            var js = await reader.ReadToEndAsync();
            return new HtmlString($@"<script type=""text/javascript"">{js}</script>");
        }
    }

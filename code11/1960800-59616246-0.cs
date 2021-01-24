lang-cs
public static WebGridColumn GridColumnFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> html, Expression<Func<TModel, TValue>> exp, string header = null, Func<dynamic, object> format = null, string style = null, bool canSort = true)
{
    var metadata = ModelMetadata.FromLambdaExpression(exp, new ViewDataDictionary<TModel>());
    var modelText = ExpressionHelper.GetExpressionText(exp);
    if (format == null && metadata.DisplayFormatString != null)
    {
        format = (item) => string.Format(metadata.DisplayFormatString, item[modelText] ?? String.Empty);
    }
    return new WebGridColumn()
    {
        ColumnName = modelText,
        Header = header ?? metadata.DisplayName ?? metadata.PropertyName ?? modelText.Split('.').Last(),
        Style = style,
        CanSort = canSort,
        Format = format
    };
}
Anywhere you would normally use `WebGrid.Column()` instead use `Html.GridColumnFor()`.
lang-cs
columns: grid.Columns(
    Html.GridColumnFor(model => model.Name),
    Html.GridColumnFor(model => model.Birthdate),
    Html.GridColumnFor(model => model.Address.Physical.StreetNumber),
    Html.GridColumnFor(model => model.Address.Physical.StreetName),
)
That is beautiful...
## What's going on?
It uses built-in Expression functionality to get the full property name to pass to the WebGridColumn constructor, and gets the already built-in metadata from MVC to get the name to display for headers, and check for formatting.
It also accepts overrides for the header and format values, so you can set them yourself; you may want one Person object for multiple pages, but some to call the `Birthdate` field "Birthday", and maybe others to call it "Date of Birth" (we try to avoid that, but sometimes it's an end user requirement), or show only the day and month:
lang-cs
Html.GridColumnFor(model => model.Birthdate, format: (item) => item.Birthdate.ToString("MM/dd"))

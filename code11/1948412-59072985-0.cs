csharp
public static (int, int) ManageDataTable<TModel>(
    List<TModel> models,
    HttpRequestBase request,
    Func<string, Func<TModel, bool>> filterProvider)
    where TModel : class
{
    string search = request["search[value]"];//arama
    if (!string.IsNullOrEmpty(search))
    {
        var filter = filterProvider(search);
        models = models.Where(filter).ToList();
    }
    return (filteredResultCount, totalRecord);
}
You'd call that like this:
csharp
DataTableHelper.ManageDataTable(glAccounts, Request,
    search => model => model.Name.Contains(search));
This approach is effectively a higher-ordered method. Alternatively, you could take a `Func<TModel, string, bool>` like this:
csharp
public static (int, int) ManageDataTable<TModel>(
    List<TModel> models,
    HttpRequestBase request,
    Func<TModel, string, bool> filter)
    where TModel : class
{
    string search = request["search[value]"];//arama
    if (!string.IsNullOrEmpty(search))
    {
        models = models.Where(model => filter(model, search)).ToList();
    }
    return (filteredResultCount, totalRecord);
}
You'd call that like this:
csharp
DataTableHelper.ManageDataTable(glAccounts, Request,
    (model, search) => model.Name.Contains(search));
It doesn't matter very much which of those you use - but it's worth making sure you understand both of them.

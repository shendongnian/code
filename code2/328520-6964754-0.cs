    @(Html.Telerik().Grid<ProductListItem>()
    .Name("Grid")
    .Columns(columns =>
    {
           columns.Bound(o => o.Current.Name).Sortable(true).Filterable(false).Width(150);
           columns.Template(
                @<text>
                    @String.Join("<br />", item.Categories)
                </text>)
                .Sortable(true).Filterable(false).Width(200);
           //other column bindings...
    })
    .DataBinding(dataBinding => dataBinding.Ajax().Select(Model.GridAjaxRequestAction.ActionName, Model.GridAjaxRequestAction.ControllerName))
    .Pageable(settings => settings.Total(Model.TotalRow))
    .EnableCustomBinding(true)
    .Sortable()
    .Filterable()

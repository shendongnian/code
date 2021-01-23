    @(Html.Telerik().Grid<ProductListItem>()
        .Name("Grid")
        .Columns(columns =>
        {
               columns.Bound(o => o.Current.Name).Sortable(true).Filterable(false).Width(150);
               columns.Template(
                    @<text>
                        <table border=0>
                             @foreach(var category in item.Categories){
                                 <tr><td>@category</td></tr>
                             }
                        </table>
                    </text>)
                    .Sortable(true).Filterable(false).Width(200);
               //other column bindings...
        })
        .DataBinding(dataBinding => dataBinding.Ajax().Select(Model.GridAjaxRequestAction.ActionName, Model.GridAjaxRequestAction.ControllerName))
        .Pageable(settings => settings.Total(Model.TotalRow))
        .EnableCustomBinding(true)
        .Sortable()
        .Filterable()

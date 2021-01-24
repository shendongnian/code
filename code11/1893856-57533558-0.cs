    @(Html.Kendo().Grid<OrderViewModel>(Model)
        .Name("order-grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.CreatedAt).Format("{0:MM/dd/yyyy}");
            columns.Bound(c => c.SalesNumber);
            columns.Bound(c => c.MaterialNumber);
            columns.Bound(c => c.SerialNumber);
            columns.Bound(c => c.CompletionDate).EditorTemplateName("CompletionDate");
               
            columns.Bound(c => c.OrderComplete);
            columns.ForeignKey(c => c.ProductionLineId, (System.Collections.IEnumerable)ViewData["ProductionLines"], "Id", "Name");
            columns.Command(command => { command.Edit(); });
            columns.Command(command => { command.Destroy(); });
        })
        .ToolBar(toolbar => toolbar.Create())
        .Editable(editable => editable.Mode(GridEditMode.InLine))
        .DataSource(ds =>
        ds.Ajax()
        .ServerOperation(false)
        .Model(model =>
        {
            model.Id(p => p.Id);
            model.Field(p => p.ProductionLineId).DefaultValue("4f03f3a1-eda3-462a-b873-69f4baf5e8a5");
        })
        .Read(read => read.Action("GetOrderList", "Order"))
        .Update(update => update.Action("EditOrderInLine", "Order"))
        .Create(create => create.Action("CreateNewOrder", "Order"))
        .Destroy(destroy => destroy.Action("DeleteOrder", "Order"))
        )
        .HtmlAttributes(new { style = "height: 100%"})
        .Sortable()
        .Filterable()
     )

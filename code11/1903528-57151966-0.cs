    @(Html.Kendo().Grid<SQDCDashboard.Core.ViewModels.SafetyIncidentViewModel>()
        .Name("safetyincident-grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.CreatedAt).HtmlAttributes(new { style = "width: 22%" }).Format("{0:MM/dd/yyyy}");
            columns.Bound(c => c.Type).HtmlAttributes(new { style = "width: 22%" });
            columns.Bound(c => c.Description).HtmlAttributes(new { style = "width: 22%" });
            columns.ForeignKey(c => c.ProductionLineId, (System.Collections.IEnumerable)ViewData["ProductionLines"], "Id", "Name").HtmlAttributes(new { style = "width: 22%" });
            columns.Command(command => { command.Edit(); }).HtmlAttributes(new { style = "width: 12%" });
        })
        .ToolBar(toolbar => toolbar.Create().Text("New Safety Incident"))
        .Editable(editable => editable.Mode(GridEditMode.InLine))
        .DataSource(ds =>
            ds.Ajax()
              .ServerOperation(false)
              .Model(model =>
                  {
                      model.Id(p => p.Id);
                      model.Field(p => p.ProductionLineId).DefaultValue(Model.DefaultProdLine);
               })
               .Read(read => read.Action("GetSafetyIncidentList", "Safety"))
               .Update(update => update.Action("EditSafetyIncidentInLine", "Safety"))
               .Create(create => create.Action("CreateNewSafetyIncident", "Safety"))
               )
         .HtmlAttributes(new { style = "height: 100%" })
         .Sortable()
         .Filterable()
         .Pageable()
         .Mobile()
    )

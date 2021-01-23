        @(Html.Kendo().Grid<YOURModel>()
                        .Name("yournameGrid")
                        .Columns(columns =>
                        {
                          columns.Bound(device => device.Id),
                          columns.ForeignKey(model => model.HeadSetId, (System.Collections.IEnumerable)ViewData["headsets"], "Id", "Name");
                        })
                         .DataSource(dataSource => dataSource
                            .Ajax()
                            .Model(model =>
                            {
                              model.Id(device => device.Id);
                              model.Field(d => d.HeadSetId).DefaultValue(ViewData["defaultHeadSetId"]);
                             })
                            .Read(read => read.Action("FunctionHere", "ControllerHere"))
           )

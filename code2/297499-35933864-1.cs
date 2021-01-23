     @Html.Grid(Model).Columns(columns =>
                        {
                            columns.Add(c => c.ConsumerNo).Titled("Consumer No").SetWidth(70).Filterable(true);
                            columns.Add(c => c.ConsumerName).Titled("Consumer Name").SetWidth(200).Filterable(true);
                            columns.Add(c => c.MobileNo).Titled("Mobile No").SetWidth(70).Filterable(true);
                            columns.Add(c => c.Address).Titled("Address").SetWidth(200).Filterable(true);
                            columns.Add(c => c.AreaName).Titled("Area Name").SetWidth(70).Filterable(true);
                            columns.Add(c => c.StaffName).Titled("Staff Name").SetWidth(100).Filterable(true);
                            columns.Add().Encoded(false).Sanitized(false).Titled("INSPECT").SetWidth(60).RenderValueAs(o => Html.ActionLink("INSPECT", "InspForm", new { id = o.UniqueConsumerId, style = "background-image:url('~/Images/orderedList1.png')" }));                       
    }).WithPaging(10).Sortable(true)

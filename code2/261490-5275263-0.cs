     <%= Html.Telerik().Grid<SerializableAdmin>()
                        .Name("Grid")
                        .Columns(colums =>
                         {
                             colums.Bound(c => c.FirstName);
                             colums.Bound(c => c.Id);
                             colums.Bound(c => c.Id).ClientTemplate("<span class=\"<#=DueDate#>\"</span>"); 
                         })
                %>

        <%= Html.Telerik().Grid<SerializableAdmin>()
                            .Name("Grid")
                            .Columns(colums =>
                             {
                                 colums.Bound(c => c.FirstName);
                                 colums.Bound(c => c.Id);
                                 colums.Bound(c => c.Id).ClientTemplate("<span class=\"<#=DateCol1Css#>\"<#=DateCol1#></span>");
    colums.Bound(c => c.Id).ClientTemplate("<span class=\"<#=DateCol2Css#>\"<#=DateCol2#></span>");
    colums.Bound(c => c.Id).ClientTemplate("<span class=\"<#=DateCol3Css#>\"<#=DateCol3#></span>");
     
                             })
                    %>

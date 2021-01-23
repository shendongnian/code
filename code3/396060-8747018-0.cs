    <input type="text" id="columnHider"/>
    <br />
    <button type="button" id="columnButton">Click</button>
    
    @model IEnumerable<Customer>
    
    @(Html.Telerik().Grid(Model)
            .Name("TelerikGrid")
            .Columns(columns =>
            {
                columns.Bound(c => c.CustomerID);
                columns.Bound(c => c.CompanyName);
                columns.Bound(c => c.ContactName);
                columns.Bound(c => c.Address);
                columns.Bound(c => c.City);
            })
            .Pageable(pageSettings => pageSettings.Enabled(true).PageSize(10))
            .ColumnContextMenu()
    )
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#columnButton").click(function () {
                var grid = $("#TelerikGrid").data("tGrid");
                var columnString = $("#columnHider").val();
                grid.hideColumn(columnString);
            });
        });
    </script>

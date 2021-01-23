        <table> 
        <thead> 
        @{var table = Dnn.ReportResults();}
    <tr>
        @foreach (DataColumn col in table.Columns)
        {  <th>@col.ColumnName
            </th>  }
    </tr>
    </thead>
    <tbody>
        @foreach (DataColumn col in table.columns)
        {
            if (@col.ColumnNamn == Request.QueryString["foo"])
            {
        foreach (DataRow row in Dnn.ReportResults().Rows)
        {  <tr>
            @foreach (var value in row.ItemArray)
            {  <td>@value
                </td>  
            }
        </tr>
        }
            }
        }
    </tbody>

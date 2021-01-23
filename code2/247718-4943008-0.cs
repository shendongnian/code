    @using System.Data;
    @model DataTable
    <table id="example" class="display">
        <thead>
            <tr>
                @{
                    foreach (DataColumn col in Model.Columns)
                    {
                    <th>@col.ColumnName
                    </th>
                    }
                }
            </tr>
        </thead>
        <tbody>
            @{
                foreach (DataRow row in Model.Rows)
                {
                <tr>
                    @{foreach (DataColumn col in Model.Columns)
                      {
                        <td>@row[col]
                        </td>
                      }
                    }
                </tr>
                }
            }
        </tbody>
    </table>

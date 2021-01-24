    <table>
        <tr>
            @foreach (System.Data.DataColumn column in Model.Columns)
            {
                <th>
                    @column.ColumnName
                </th>
            }
        </tr>
        <tbody>
            @foreach (System.Data.DataRow row in Model.Rows)
            {
                <th>
                    @foreach (var cell in row.ItemArray)
                    {
                        @cell.ToString();
                    }
                </th>
            }
        </tbody>
    </table>

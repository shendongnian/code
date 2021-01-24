    @model dynamic
    @using System.Reflection
    @{
        var properties = Model[0].GetType().GetProperties();
    }
    <table>
        <tr>
            @foreach (var item in properties)
            {
                <td>
                    @item.Name
                </td>
            }
        </tr>
        @foreach (var item in Model)
        {
            <tr>
                @foreach (PropertyInfo p in properties)
                {
                    <td>@p.GetValue(item)</td>
                }
            </tr>
        }
               
    </table>

    @{
        ViewBag.Title = "All messages";
    }
    @model YourNamespace.Models.User
        <table>   
            <tr>
                <th>Message</th>     
            <tr>           
            @foreach (var el in Model.ListMessage)
            {
                <tr>
                    <td>@Html.DisplayFor(m => el)</td>
                </tr>
            }
        </table>
       // you can access Model.Id, Model.Name, Model.Date, Model.Message in this view too

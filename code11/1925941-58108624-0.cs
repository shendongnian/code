    @model  List<dynamic>
    <table>
        <tr>
            @foreach (var item in Model.ElementAt(0).GetType().GetProperties())
            {
                <td>
                    @item.Name
                </td>
            }
        </tr>
        @foreach (var item in Model)
        {
            if (item.GetType() == typeof(Person))
            {
                var person = item as Person;
    
                <tr>
                    @person.Name
                </tr>
            }
            if (item.GetType() == typeof(Team)) {
    
                var team = item as team;
                   
                    <tr>
                         @team.Name
                   </tr>
    
            }
    
        }
    </table>

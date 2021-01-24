    @using System.Reflection;
    @{
       var fields = typeof(DtoForeignClient).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
     }
    @foreach (var ft in Model.DtoForeignClients)
    {
        <tr>        
          @foreach(FieldInfo f in fields)
          {
             <td>@f.GetValue(ft)</td>
          }
        <tr>
    }

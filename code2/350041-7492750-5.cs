     @{int i = 0;
       var item = new MVC3TestSite.Models.TestData();
    }
    <table>
   
        @while(i < Model.Data.Count){
            
            <tr>
                @for(var j = 1; j <= Model.Limit; j++){
                    item = Model.Data[i];
                    <td>@item.Name</td>
                    <td>
                        <div id="Team-@item.Id-FilterRadio" class="TeamFilterRadio">
                            <input type="radio" id="Team-@item.Id-ON" name="Team-@item.Id" checked="checked"/><label for="Team-@item.Id-ON"">ON</label>
                            <input type="radio" id="Team-@item.Id-OFF" name="Team-@item.Id"  /><label for="Team-@item.Id-OFF"">OFF</label>
                        </div>
                    </td>
                    if (++i == Model.Data.Count) { break; } 
                }
            </tr>
        }
    </table>

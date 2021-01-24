C#
@using (Html.BeginForm("UpdateRoles","AdminRoles",FormMethod.Post))  
{ 
  @for (var i = 0; i < Model.Count(); i++)  
  { 
    <tr>
       <td>
           //to pass id to your post method
           @Html.HiddenFor(m => m[i].Id) 
           @Html.DisplayFor(m => m[i].Name)
       </td>
       <td>
           @Html.CheckBoxFor(m => m[i].IsChecked, new { })
       </td>
   </tr>
 }
 <input id="Submit" type="submit" value="submit" />   
}  
Controller : 
     [HttpPost]  
     public ActionResult UpdateRoles(List<CompanyRole> model)
     {  
         //your logic
         return View();  
     }
Model :
C#
public class CompanyRole {
    public int Id {get; set;}
    public string Name {get; set;}
    public bool IsChecked {get; set;}
}

    @model Checkpoint.Models.Checklist
    <table>
        @for(int i = 0; i < Model.Tasks.Count; i++)
        {
            <tr>
               <td>@Model.Tasks[i].TaskName</td>
               <td data-ftid="@Model.Tasks[i].TaskId">
                   @using (Html.BeginForm("Index", "Check", FormMethod.Post))
                   {
                       @Html.HiddenFor(x => Model.Tasks[i].TaskId, new { Name="TaskId" })
                       @Html.RadioButtonFor(x => Model.Tasks[i].IsDone, false, new { Name="IsDone" })<span>Incomplete</span>
                       @Html.RadioButtonFor(x => Model.Tasks[i].IsDone, true, new { Name="IsDone" })<span>Complete</span>
                       <button role="button" type="submit" name="taskAction">Submit</button>
                  }
               </td>
           </tr>
        }
    </table>

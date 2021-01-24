    @model Checkpoint.Models.Task
    <tr>
        <td>@Model.TaskName</td>
        <td data-ftid="@Model.TaskId">
            @using (Html.BeginForm("Index", "Check", FormMethod.Post))
            {
                @Html.HiddenFor(x => x.TaskId, new { id = "Task_" + Model.TaskId + "_hidIsDone" })
                @Html.RadioButtonFor(x => x.IsDone, false, new { id = "Task_"+ Model.TaskId + "_radIsDoneF" })<span>Incomplete</span>
                @Html.RadioButtonFor(x => x.IsDone, true, new { id = "Task_" + Model.TaskId + "_radIsDoneT" })<span>Complete</span>
                <button role="button" type="submit" name="taskAction">Submit</button>
            }
        </td>
    </tr>

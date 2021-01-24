public IEnumerable<LeaveStatus> GetAvailableStatuses(){
    return Enum.GetValues(typeof(LeaveStatus)).Where(e => e >= Status);
}
**View** 
@Html.EnumDropDownListFor(m => m.LeaveStatus, Model.GetAvailableStatuses().Select(s => new SelectListItem {
    Text = s.ToString(),
    Value = ((int)s).ToString()
}).ToList(), "-Please select-", new { @class = "col-sm-10", @required = "required" })
Note that I took a guess at what your condition might be, but you can update that in the `GetAvailableStatuses` method. 

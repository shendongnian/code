public ActionResult Index()
{
   var accounts = db.Accounts;
   var groups = db.Groups;
   // this line creates a Dictionary<int, string> where group_id is the key and group_name the value
   var groupsNames = groups.ToDictionary(x => x.group_id, x => x.group_name);
   ViewBag.GroupsNames = groupsNames;
   return View(accounts);
}
Then in the view declare a function like this (usually before the html part)
@functions
{
    public List<SelectListItem> CreateSelectList(int groupId)
    {
        var newList = new List<SelectListItem>();
        foreach (var val in (Dictionary<int, string>)ViewBag.GroupsNames)
        {
            newList.Add(new SelectListItem
            {
                Text = val.Value,
                Value = val.Key.ToString(),
                Selected = val.Key == groupId
            });
        }
        return newList;
    }
}
and use it to populate the drop down list
grid.Column("group_id", "Group", format: (item) => Html.DropDownList("GroupId", CreateSelectList((int)item.group_id)))
Or, if you don't need the drop down list but instead just want to display the name of the group you can do
grid.Column("group_id", "Group", format: (item) => ((Dictionary<int, string>)ViewBag.GroupsNames)[item.group_id])
and in this case you don't need the function.

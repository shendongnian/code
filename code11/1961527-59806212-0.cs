@if(Edit.Enabled) {
  @RenderPage("_Shared__ContentGroup-Info.cshtml")
}
Save this to a filename `_Shared__ContentGroup-Tabs.cshtml` (above)
@using System.Data
@using DotNetNuke.Data
@using DotNetNuke.Entities.Tabs
@*
    This sub template is intended to
    a) reveal whether or not the Content item is shared and
    b) show links to those pages
    Reminder the .Parent().EntityGuid is what is stored in
    Dnn.Module.ModuleSettings["ToSIC_SexyContent_ContentGroupGuid"]
*@
@{
  string sql = @"
      SELECT DISTINCT TabID
      FROM TabModules
        INNER JOIN ModuleSettings ON TabModules.ModuleID = ModuleSettings.ModuleID
      WHERE ModuleSettings.SettingValue = '{0}'";
  sql = string.Format(sql, Dnn.Module.ModuleSettings["ToSIC_SexyContent_ContentGroupGuid"]);
  IList<int> tabs;
  using (IDataContext db = DataContext.Instance()) {
      tabs = db.ExecuteQuery<int>(CommandType.Text, sql).ToList();
  }
}
This Content item is shared to @(tabs.Count - 1) other page(s)
@foreach(int tabId in tabs
  .Where(t => t != Dnn.Tab.TabID)
) {
<a href="/tabid/@tabId)">@TabController.Instance.GetTab(tabId, Dnn.Portal.PortalId).TabName</a>
}

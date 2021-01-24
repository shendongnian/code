using DevExprss.XtraGrid.Views.Grid.ViewInfo;
...
this.gridView.CustomDrawGroupRow += (s, e) => 
{
    GridGroupRowInfo groupInfo = e.Info as GridGroupRowInfo;
    groupInfo.GroupText = "Custom group text";
}

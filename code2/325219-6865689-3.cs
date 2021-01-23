    public partial class _Default : Page
    {
      private const string DataGridSelectedRowCssClass = "selectedRow";
      protected void Page_Load(object sender, EventArgs e)
      {
        Page.ClientScript.RegisterClientScriptBlock(
          GetType(),
          "dataGrid_selectRow",
          string.Format(
            @"(function (dataGrid, $, undefined) {{
              dataGrid.selectRow = function (row) {{
            
                $(row).siblings('.{0}').css('background-color', '#{1}').end().css('background-color', '#{2}').addClass('{0}');
                }}
               
              }})(window.dataGrid = window.dataGrid || {{}}, jQuery);",
            DataGridSelectedRowCssClass,
            DataGridTest.ItemStyle.BackColor.ToArgb().ToString("X8").Substring(2), 
            DataGridTest.SelectedItemStyle.BackColor.ToArgb().ToString("X8").Substring(2)),
          true);
      }
      protected void DataGridTest_ItemCreated(object sender, DataGridItemEventArgs e)
      {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.SelectedItem)
        {
          e.Item.Attributes["onclick"] = "dataGrid.selectRow(this);";
          if (e.Item.ItemType == ListItemType.SelectedItem)
          {
            e.Item.CssClass = string.Format("{0} {1}", e.Item.CssClass, DataGridSelectedRowCssClass);
          }
        }
      }
    }

    using DevExpress.XtraTreeList;
    private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
    {
      // Modifying the appearance settings used to paint the "Budget" column's cells
      // whose values are greater than 500,000 .
      if (e.Column.FieldName != "Budget") return;
      if (Convert.ToInt32(e.Node.GetValue(e.Column.AbsoluteIndex)) > 500000)
      {
        e.Appearance.BackColor = Color.FromArgb(80, 255, 0, 255);
        e.Appearance.ForeColor = Color.White;
        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
      }
    }

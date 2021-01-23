    namespace UCS_Web.uP.UserControls
    {
       public partial class StdList : StdList
       {
          private ICustomTable m_custom = null;
    
        }
    
      protected virtual void _gridView_DataBound(object sender, EventArgs e)
      {
          if (_gridView.Rows.Count > 0)
          {
              for (int i = _gridView.Rows.Count + 1; i <= _gridView.PageSize - 1; i++)
              {
                  GridViewRow row = new GridViewRow(
                          0,
                          0,
                          DataControlRowType.DataRow,
                      //(i % 2 > 0) ? datacontrolrowstate.normal : datacontrolrowstate.alternate);
                          DataControlRowState.Alternate);
    
                  foreach (DataControlField field in _gridView.Columns)
                  {
                      TableCell cell = new TableCell();
                      cell.Text = "&nbsp;";
                      row.Cells.Add(cell);
                  }
            //row.Attributes.Add("OnClick", "javascript:alert();");
                  row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                  _gridView.Controls[0].Controls.AddAt(i, row);
              }
          }
      }
    
      protected virtual void _gridView_RowCommand(object sender, GridViewCommandEventArgs e)
      {
          // I do nothing for now... A subclass could override me and do very nice stuff
      }

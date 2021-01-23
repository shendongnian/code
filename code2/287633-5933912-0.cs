    protected void ASPxGridView1_Init(object sender, EventArgs e)
      {
          GridViewDataTextColumn colTotal = new GridViewDataTextColumn();
          colTotal.Caption = "Total";
          colTotal.FieldName = "Total";
          colTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
          colTotal.VisibleIndex = ASPxGridView1.VisibleColumns.Count;
          colTotal.PropertiesTextEdit.DisplayFormatString = "n0";
          ASPxGridView1.Columns.Add(colTotal);
    
      }
    
    protected void ASPxGridView1_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
      {
          if (e.Column.FieldName == "Total")
          {
              decimal risk = Convert.ToDecimal(e.GetListSourceFieldValue("RISK"));
              decimal mv = Convert.ToDecimal(e.GetListSourceFieldValue("MV_BERND"));
              decimal ipotek = Convert.ToDecimal(e.GetListSourceFieldValue("IPOTEK"));
             
    
              e.Value = risk - mv - ipotek;
          }
    
      }

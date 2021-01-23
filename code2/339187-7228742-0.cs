    Form1 {
        UpdateRowMethod() {
          DataRow Row = GetSelectedRow()
          Form2 frm;
          frm = new Form2(Row.Field1, Row.Field2, Row.Field3)
          if frm.ShowDialog() = OK {
             Row.Field1 = frm.Property1
             Row.Field2 = frm.Property2
             Row.Field3 = frm.Property3
             DataGridView1.InvalidateSelectedRow()
          }
       }
    }

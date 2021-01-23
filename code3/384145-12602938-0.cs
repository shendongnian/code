    int primaryKey =0; 
    RadioButton radioButton; 
    for (int i = 0; i < RadGrid1.Items.Count; i++) {
     radioButton = RadGrid1.Items[i].FindControl("rdSelect") as RadioButton;
     If (radioButton.Checked) {
       primaryKey = RadGrid1.MasterTableView.Items[e.Item.ItemIndex]["ID"].Text; 
      } 
    } 

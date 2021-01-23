    cb = new SqlCommandBuilder(da);
    var itemId = int.Parse(txtID.Text);
    var row = ds.Tables["Inventory"].Rows.Find(itemId);
    row["ItemCode"] = txtId.Text;
    row["Description"] = txtId.Text;
    da.Update(ds, "Inventory");
    ds.Tables["Inventory"].AcceptChanges();
    MessageBox.Show("Record updated successfully.");

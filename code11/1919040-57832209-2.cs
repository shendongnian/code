    string prodCode = txtProductCode.Text;
    decimal qty = Convert.ToInt32(txtQty.Text);
    decimal price = Convert.ToInt32(txtPrice.Text);
    //does the row exist?
    var ro = dt.FindByProdCode(prodCode); //the typed datatable will have a FindByXX method generated on whatever column(s) are the primary key
    if(ro != null){
      ro.Price = price; //update the existing row
      ro.Qty += qty;
    } else {
      dt.AddXXRow(prodCode, qty, price); //AddXXRow is generated for typed datatables depending on the table name
    }

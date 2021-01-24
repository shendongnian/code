    //ds is DataSet
    foreach (DataRow dRow in ds.Tables[0].Rows)
    {
      TableCell pNameCell = new TableCell();
      TableCell pDescCell = new TableCell();
      TableCell pPriceCell = new TableCell();
      TableCell pStockCell = new TableCell();
      TableCell buyProduct = new TableCell();
      HyperLink hl = new HyperLink();
      TableRow row = new TableRow();
    
      pNameCell.Text = dRow["name"].ToString();
      row.Cells.Add(pNameCell);
      pDescCell.Text = dRow["description"].ToString();
      row.Cells.Add(pDescCell);
      pPriceCell.Text = dRow["price"].ToString();
      row.Cells.Add(pPriceCell);
      pStockCell.Text = dRow["Qty"].ToString();
      row.Cells.Add(pStockCell);
      hl.Text = "Add To Cart";
      hl.NavigateUrl = "BuyProduct.aspx?id="+ dRow["pro_id"].ToString();
      hl.CssClass = "btn btn-primary";
      buyProduct.Controls.Add(hl);
      row.Cells.Add(buyProduct);
      //TProducts is table ID
      TProducts.Rows.Add(row);
    }

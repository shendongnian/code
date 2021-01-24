    foreach (DataRow dataRow in dt.Rows)
    {
      string lineNumberInput = dataRow[1].ToString();
      string itemCodeInput = dataRow[12].ToString();
      string itemNameInput = dataRow[13].ToString();
      string QtyInput = dataRow[14].ToString();
      string UnitPriceInput = dataRow[15].ToString();
      //string Discount = dataRow[""].ToString();
      string lineTotalInput = dataRow[16].ToString();
      string wasReturnedInput = dataRow[17].ToString();
    
      var Cell_LineNumberList = new PdfPCell(new Phrase(lineNumberInput, 
    tablefont));
      var Cell_ItemCodelist = new PdfPCell(new Phrase(itemCodeInput, tablefont));
      var Cell_ItemNamelist = new PdfPCell(new Phrase(itemNameInput, tablefont));
      var Cell_Qtylist = new PdfPCell(new Phrase(QtyInput, tablefont));
      var Cell_UnitPricelist = new PdfPCell(new Phrase(UnitPriceInput, tablefont));
      var Cell_Discountlist = new PdfPCell(new Phrase("None", tablefont));
      var Cell_LineTotallist = new PdfPCell(new Phrase(lineTotalInput, tablefont));
      var Cell_WasReturnedlist = new PdfPCell(new Phrase(wasReturnedInput, 
    tablefont));
    
      t.AddCell(Cell_LineNumberList);
      t.AddCell(Cell_ItemCodelist);
      t.AddCell(Cell_ItemNamelist);
      t.AddCell(Cell_Qtylist);
      t.AddCell(Cell_UnitPricelist);
      t.AddCell(Cell_Discountlist);
      t.AddCell(Cell_LineTotallist);
      t.AddCell(Cell_WasReturnedlist);
    
    }

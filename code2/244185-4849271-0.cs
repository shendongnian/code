    HtmlTable tbProductImage = new HtmlTable();
    HtmlTableRow trImageRow = new HtmlTableRow();
    for (int j = 0; j < columnCount; j++)
    {
        if (filteredFileList.Count != 0)
        {
    
            HtmlTableCell tdImageCell = new HtmlTableCell();
            Image imageProduct = new Image();
            imageProduct.ID = "id";
            imageProduct.ImageUrl = "url";
            tdImageCell.Controls.Add(imageProduct);
            trImageRow.Cells.Add(tdImageCell);
        }
    }
    tbProductImage.Rows.Add(trImageRow);

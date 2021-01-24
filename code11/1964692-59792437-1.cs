    foreach (GridViewRow gridViewRow in gvCartView.Rows)
    {
        foreach (TableCell gridViewCell in gridViewRow.Cells)
        {
            Font font = new Font();
            font.Color = new BaseColor(gvCartView.RowStyle.ForeColor);
    		var gridText = "";
    		if (((DataControlFieldCell)gridViewCell).ContainingField is TemplateField)
    		{
    			if (((DataControlFieldCell)gridViewCell).ContainingField.HeaderText == "Quantity")
    			{
    				gridText = (gridViewCell.FindControl("tb_Quantity") as TextBox).Text;
    			}
    		}
    		else
    		{
    			gridText = gridViewCell.Text;
    		}
            PdfPCell pdfCell = new PdfPCell(new Phrase(gridText, font));
            pdfCell.BackgroundColor = new BaseColor(gvCartView.RowStyle.BackColor);
            pdfTable.AddCell(pdfCell);
        }
    }

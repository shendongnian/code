    int i = DgInvoiceLines.SelectedIndex;
                string iqty = ((DataRowView)DgInvoiceLines.SelectedItem)["Inv_Quantity"].ToString();
                string gqty = ((DataRowView)DgInvoiceLines.SelectedItem)["Grn_Quantity"].ToString();
                string iprice = ((DataRowView)DgInvoiceLines.SelectedItem)["Inv_Price"].ToString();
                string gprice = ((DataRowView)DgInvoiceLines.SelectedItem)["Grn_Price"].ToString();
                string itotal = ((DataRowView)DgInvoiceLines.SelectedItem)["Inv_Total"].ToString();
                string gtotal = ((DataRowView)DgInvoiceLines.SelectedItem)["Grn_Total"].ToString();
                DataGridCell InvQtyCell = GetCell(i, 2);
                DataGridCell GrnQtyCell = GetCell(i, 3);
                DataGridCell InvPriCell = GetCell(i, 4);
                DataGridCell GrnPriCell = GetCell(i, 5);
                DataGridCell InvTotCell = GetCell(i, 6);
                DataGridCell GrnTotCell = GetCell(i, 7);
                string InvoiceCellContentType = InvQtyCell.Content.GetType().Name.ToString();
                string GRNCellContentType = GrnQtyCell.Content.GetType().Name.ToString();
                string InvPriContentType = InvPriCell.Content.GetType().Name.ToString();
                string GrnPriContentType = GrnPriCell.Content.GetType().Name.ToString();
                string InvTotCellType = InvTotCell.Content.GetType().Name.ToString();
                string GrnTotCelType = GrnTotCell.Content.GetType().Name.ToString();
                if (iqty == gqty) 
                {
                    if (InvoiceCellContentType == "TextBlock") ((TextBlock)InvQtyCell.Content).Foreground = Brushes.DarkGreen;
                    else if (InvoiceCellContentType == "TextBox") ((TextBox)InvQtyCell.Content).Foreground = Brushes.DarkGreen;
                    if (GRNCellContentType == "TextBlock") ((TextBlock)GrnQtyCell.Content).Foreground = Brushes.DarkGreen;
                    else if (GRNCellContentType == "TextBox") ((TextBox)GrnQtyCell.Content).Foreground = Brushes.DarkGreen;
                }
                else
                {
                    if (InvoiceCellContentType == "TextBlock") ((TextBlock)InvQtyCell.Content).Foreground = Brushes.Red;
                    else if (InvoiceCellContentType == "TextBox") ((TextBox)InvQtyCell.Content).Foreground = Brushes.Red;
                    if (GRNCellContentType == "TextBlock") ((TextBlock)GrnQtyCell.Content).Foreground = Brushes.Red;
                    else if (GRNCellContentType == "TextBox") ((TextBox)GrnQtyCell.Content).Foreground = Brushes.Red;
                }
                if (iprice == gprice) 
                {
                    if (InvPriContentType == "TextBlock") ((TextBlock)InvPriCell.Content).Foreground = Brushes.DarkGreen;
                    else if (InvPriContentType == "TextBox") ((TextBox)InvPriCell.Content).Foreground = Brushes.DarkGreen;
                    if (GrnPriContentType == "TextBlock") ((TextBlock)GrnPriCell.Content).Foreground = Brushes.DarkGreen;
                    else if (GrnPriContentType == "TextBox") ((TextBox)GrnPriCell.Content).Foreground = Brushes.DarkGreen;
                }
                else
                {
                    if (InvPriContentType == "TextBlock") ((TextBlock)InvPriCell.Content).Foreground = Brushes.Red;
                    else if (InvPriContentType == "TextBox") ((TextBox)InvPriCell.Content).Foreground = Brushes.Red;
                    if (GrnPriContentType == "TextBlock") ((TextBlock)GrnPriCell.Content).Foreground = Brushes.Red;
                    else if (GrnPriContentType == "TextBox") ((TextBox)GrnPriCell.Content).Foreground = Brushes.Red;
                }

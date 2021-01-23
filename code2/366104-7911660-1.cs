    invoice.InvoiceItems.Clear();
    foreach (ListViewItem listItem in listView1.Items)
        invoice.InvoiceItems.Add(new InvoiceItem() 
                               { ProductNumber = listItem.SubItems[0].Text, 
                                 PartNumber = listItem.SubItems[1].Text}
                            );

    Documents oDoc = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
    int docEntry = 109;
    int lineNum = 2;
    
    // Load your sales orders
    if (oDoc.GetByKey(docEntry))
    {
        // Go through your line items
        for (int i = 0; i < oDoc.Lines.Count; i++)
        {
            oDoc.Lines.SetCurrentLine(i);
            if (oDoc.Lines.LineNum == lineNum) //Find your line number that you want delete.
            {
                oDoc.Lines.Delete(); //Delete
                break;
            }
        }
    
        // Update your sales order
        if (oDoc.Update() != 0)
            MessageBox.Show(oCompany.GetLastErrorDescription());
    }

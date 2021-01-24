    private void Delete_Single_Line_Row(string docentry, int lNum)
            {
                SAPbobsCOM.Documents oSalesOrd = null;
                oSalesOrd = (SAPbobsCOM.Documents)SBOC_SAP.G_DI_Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
                int docEntry = Convert.ToInt32(docentry);
                int lineNum = lNum;
    
                // Load your sales orders
                if (oSalesOrd.GetByKey(docEntry))
                {
                    // Go through your line items
                    for (int i = 0; i < oSalesOrd.Lines.Count; i++)
                    {
                        oSalesOrd.Lines.SetCurrentLine(i);
                        if (oSalesOrd.Lines.LineNum == lineNum) //Find your line number that you want delete.
                        {
                            oSalesOrd.Lines.Delete(); //Delete
                            break;
                        }
                    }
                    // Update your sales order
                    int result = oSalesOrd.Update();
    
                }
            }    enter code here

                if (bgwInvoiceDetails.RowCount > 0)
                {
                    if (ADevExpress.DevExpressMethods.IsCorrectRowHandle(bgwInvoiceDetails, GridControl.NewItemRowHandle))
                    {
                        bgwInvoiceDetails.SetRowCellValue(GridControl.NewItemRowHandle, colExchangeType, leExchangeCode.EditValue);
                        bgwInvoiceDetails.SetRowCellValue(GridControl.NewItemRowHandle, colExchangePrice, teExchangePrice.EditValue);
                    }
                    for (int i = 0; i < bgwInvoiceDetails.RowCount; i++)
                    {
                        if (ADevExpress.DevExpressMethods.IsCorrectRowHandle(bgwInvoiceDetails, i))
                            bgwInvoiceDetails.SetRowCellValue(i, colExchangePrice, teExchangePrice.EditValue);
                    }
                }

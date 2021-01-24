                //    //TxnTaxDetail
                //    TxnTaxDetail txnTaxDetail = new TxnTaxDetail();
                //    Line taxLine = new Line();
                //    taxLine.DetailType = LineDetailTypeEnum.TaxLineDetail;
                //    TaxLineDetail taxLineDetail = new TaxLineDetail();
                //    taxLineDetail.TaxRateRef = stateTaxCode.SalesTaxRateList.TaxRateDetail[0].TaxRateRef;
                //    txnTaxDetail.TxnTaxCodeRef = new ReferenceType
                //    {
                //        name = stateTaxCode.Name,
                //        Value = stateTaxCode.Id
                //    };
                //    if (customer.DefaultTaxCodeRef != null)
                //    {
                //        txnTaxDetail.TxnTaxCodeRef = customer.DefaultTaxCodeRef;
                //        taxLineDetail.TaxRateRef = customer.DefaultTaxCodeRef;
                //    }
                //    //Assigning the first Tax Rate in this Tax Code
                    
                //    taxLine.AnyIntuitObject = taxLineDetail;
                //    txnTaxDetail.TaxLine = new[] { taxLine };
                //    invoice.TxnTaxDetail = txnTaxDetail;
                invoice.GlobalTaxCalculationSpecified = true;
                invoice.GlobalTaxCalculation = GlobalTaxCalculationEnum.TaxExcluded;

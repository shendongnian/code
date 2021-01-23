        {
            try
            {
                string invoiceNumber = statementList.FirstOrDefault().Invoice.ToString().Trim();
                     
                using (Document document = new Document())
                {
                    FileStream fileStream = new FileStream(HostingEnvironment.MapPath("~/Content/reports/" + invoiceNumber + ".pdf"), FileMode.Create);
                    using (PdfSmartCopy smartCopy = new PdfSmartCopy(document, fileStream))
                    {
                        document.Open();
                        PdfReader pdfReader = new PdfReader(HostingEnvironment.MapPath("~/Content/InvoiceTemplate/invoiceTemplate.pdf"));
                                using (var memoryStream = new MemoryStream())
                                {
                                    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream))
                                    {
                                        string month = null;
                                        string day = null;
                                        string year = null;
                                        AcroFields pdfFields = pdfStamper.AcroFields;
                                        {//billing address
                                            pdfFields.SetField("BillToCompany", statementList.FirstOrDefault().BillToCompany.ToString().Trim().ToUpper());
                                            pdfFields.SetField("BillToContact", statementList.FirstOrDefault().BillToContact.ToString().Trim().ToUpper());
                                            pdfFields.SetField("ShipToCompany", statementList.FirstOrDefault().ShipToCompany.ToString().Trim().ToUpper());
                                            pdfFields.SetField("ShipToContact", statementList.FirstOrDefault().ShipToContact.ToString().Trim().ToUpper());
                                            pdfFields.SetField("PONumber", statementList.FirstOrDefault().PurchaseOrderNo.ToString().Trim());
                                            pdfFields.SetField("OrderNumber", statementList.FirstOrDefault().Order_Number.ToString().Trim());
                                            pdfFields.SetField("ShippingMethod", statementList.FirstOrDefault().Shipping_Method.ToString().Trim());
                                            pdfFields.SetField("PaymentTerms", statementList.FirstOrDefault().Payment_Terms.ToString().Trim());
                                       }
                                       pdfStamper.FormFlattening = true; // generate a flat PDF 
                                    }
                                    pdfReader = new PdfReader(memoryStream.ToArray());
                                    smartCopy.AddPage(smartCopy.GetImportedPage(pdfReader, 1));
                                }
                    }
                }
                    
                emailController.CreateMessageWithAttachment(invoiceNumber);
            }
            catch (Exception e)
            {
            }
        }

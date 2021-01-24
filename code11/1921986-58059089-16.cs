     if (PrintManager.IsSupported())
                                {
                                    printDoc = new PrintDocument();
                                    printDocSource = printDoc.DocumentSource;
                                    _totalPages = (int)Math.Ceiling(wholeItemsListForPDF.Count / (double)11);
                                    tempList = new ManifestPDFDataModel();
                                    tempList = _manifestPDFDataModel;
                                    printDoc.Paginate += PaginateManifestLabel;
                                    printDoc.GetPreviewPage += GetPreviewPageManifestLabel;
                                    printDoc.AddPages += AddPagesManifestLabel;
                                    printMan = PrintManager.GetForCurrentView();
                                    printMan.PrintTaskRequested += PrintTaskRequestedManifestLabel;
                                    PreparePrintContent(new GenericManifestPDF(_manifestPDFDataModel));
                                    try
                                    {
                                        // Show print UI
                                        await PrintManager.ShowPrintUIAsync();
                                    }
                                    catch (Exception ex)
                                    {
                                        // Printing cannot proceed at this time
                                        ContentDialog noPrintingDialog = new ContentDialog()
                                        {
                                            Title = "Printing error",
                                            Content = "\nSorry, printing can' t proceed at this time.",
                                            PrimaryButtonText = "OK"
                                        };
                                        printMan.PrintTaskRequested -= PrintTaskRequestedManifestLabel;
                                        printDoc.Paginate -= PaginateManifestLabel;
                                        printDoc.GetPreviewPage -= GetPreviewPageManifestLabel;
                                        printDoc.AddPages -= AddPagesManifestLabel;
                                        
                                        await noPrintingDialog.ShowAsync();
                                    }
                                }
                                else
                                {
                                    //Printing is not supported on this device
                                   ContentDialog noPrintingDialog = new ContentDialog()
                                   {
                                       Title = "Printing not supported",
                                       Content = "\nSorry, printing is not supported on this device.",
                                       PrimaryButtonText = "OK"
                                   };
                                    printMan.PrintTaskRequested -= PrintTaskRequestedManifestLabel;
                                    printDoc.Paginate -= PaginateManifestLabel;
                                    printDoc.GetPreviewPage -= GetPreviewPageManifestLabel;
                                    printDoc.AddPages -= AddPagesManifestLabel;
                                    await noPrintingDialog.ShowAsync();
                                    
                                }

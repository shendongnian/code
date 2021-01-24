     public class Print_UWP
        {
            PrintManager printmgr = PrintManager.GetForCurrentView();
            PrintDocument PrintDoc = null;
            PrintDocument printDoc;
            PrintTask Task = null;
            Windows.UI.Xaml.Controls.Image ViewToPrint = new Windows.UI.Xaml.Controls.Image();
    
            public Print_UWP()
            {
               
                printmgr.PrintTaskRequested += Printmgr_PrintTaskRequested;
            }
    
            public async void PrintUWpAsync(byte[] imageData)
            {
                int i = 0;
    
                while (i < 5)
                {
                    try
                    {
                        BitmapImage biSource = new BitmapImage();
                        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                        {
                            await stream.WriteAsync(imageData.AsBuffer());
                            stream.Seek(0);
                            await biSource.SetSourceAsync(stream);
                        }
    
                        ViewToPrint.Source = biSource;
                        if (PrintDoc != null)
                        {
                            printDoc.GetPreviewPage -= PrintDoc_GetPreviewPage;
                            printDoc.Paginate -= PrintDoc_Paginate;
                            printDoc.AddPages -= PrintDoc_AddPages;
                        }
    
                        this.printDoc = new PrintDocument();
                        try
                        {
                            printDoc.GetPreviewPage += PrintDoc_GetPreviewPage;
                            printDoc.Paginate += PrintDoc_Paginate;
                            printDoc.AddPages += PrintDoc_AddPages;
    
                            bool showprint = await PrintManager.ShowPrintUIAsync();
    
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
    
                        //  printmgr = null;
                        // printDoc = null;
                        // Task = null;
                        PrintDoc = null;
                        GC.Collect();
                        printmgr.PrintTaskRequested -= Printmgr_PrintTaskRequested;
                        break;
                    }
                    catch (Exception e)
                    {
                        i++;
                    }
                   
                }
            }
    
            private void Printmgr_PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
            {
                var deff = args.Request.GetDeferral();
                Task = args.Request.CreatePrintTask("Invoice", OnPrintTaskSourceRequested);
    
                deff.Complete();
    
            }
    
            async void OnPrintTaskSourceRequested(PrintTaskSourceRequestedArgs args)
            {
                var def = args.GetDeferral();
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    args.SetSource(printDoc.DocumentSource);
                });
                def.Complete();
            }
    
            private void PrintDoc_AddPages(object sender, AddPagesEventArgs e)
            {
                printDoc.AddPage(ViewToPrint);
                printDoc.AddPagesComplete();
            }
    
            private void PrintDoc_Paginate(object sender, PaginateEventArgs e)
            {
                PrintTaskOptions opt = Task.Options;
                printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
            }
    
            private void PrintDoc_GetPreviewPage(object sender, GetPreviewPageEventArgs e)
            {
                printDoc.SetPreviewPage(e.PageNumber, ViewToPrint);
            }
    
        }

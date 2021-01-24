     public async void PrintTaskCompletedManifestLabel(PrintTask sender, PrintTaskCompletedEventArgs args)
        {
            // Notify the user when the print operation fails.
            if (args.Completion == PrintTaskCompletion.Failed)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    ContentDialog noPrintingDialog = new ContentDialog()
                    {
                        Title = "Printing error",
                        Content = "\nSorry, failed to print.",
                        PrimaryButtonText = "OK"
                    };
                    printMan.PrintTaskRequested -= PrintTaskRequestedManifestLabel;
                    printDoc.Paginate -= PaginateManifestLabel;
                    printDoc.GetPreviewPage -= GetPreviewPageManifestLabel;
                    printDoc.AddPages -= AddPagesManifestLabel;
                    await noPrintingDialog.ShowAsync();
                });
            }
            else
            {
                printMan.PrintTaskRequested -= PrintTaskRequestedManifestLabel;
            }
        }

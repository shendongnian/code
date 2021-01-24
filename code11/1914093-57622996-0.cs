    protected override void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
    {
        PrintTask printTask = null;
        printTask = e.Request.CreatePrintTask("C# Printing SDK Sample", async sourceRequestedArgs =>
        {
            printTask.Options.MediaSize = Windows.Graphics.Printing.PrintMediaSize.NorthAmerica10x14;
    
            var deferral = sourceRequestedArgs.GetDeferral();
            PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
            IList<string> displayedOptions = printDetailedOptions.DisplayedOptions;
    
            // Choose the printer options to be shown.
            // The order in which the options are appended determines the order in which they appear in the UI
            displayedOptions.Clear();
    
            displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
            displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
            displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.ColorMode);
    
            // Create a new list option
            PrintCustomItemListOptionDetails pageFormat = printDetailedOptions.CreateItemListOption("PageContent", "Pictures");
            pageFormat.AddItem("PicturesText", "Pictures and text");
            pageFormat.AddItem("PicturesOnly", "Pictures only");
            pageFormat.AddItem("TextOnly", "Text only");
    
            // Add the custom option to the option list
            displayedOptions.Add("PageContent");
            
            // Create a new toggle option "Show header". 
            PrintCustomToggleOptionDetails header = printDetailedOptions.CreateToggleOption("Header", "Show header");
    
            // App tells the user some more information about what the feature means.
            header.Description = "Display a header on the first page";
    
            // Set the default value
            header.TrySetValue(showHeader);
            
            // Add the custom option to the option list
            displayedOptions.Add("Header");
            
            // Create a new list option
            PrintCustomItemListOptionDetails margins = printDetailedOptions.CreateItemListOption("Margins", "Margins");
            margins.AddItem("WideMargins", "Wide", "Each margin is 20% of the paper size", await wideMarginsIconTask);
            margins.AddItem("ModerateMargins", "Moderate", "Each margin is 10% of the paper size", await moderateMarginsIconTask);
            margins.AddItem("NarrowMargins", "Narrow", "Each margin is 5% of the paper size", await narrowMarginsIconTask);
            
            // The default is ModerateMargins
            ApplicationContentMarginTop = 0.1;
            ApplicationContentMarginLeft = 0.1;
            margins.TrySetValue("ModerateMargins");
    
            // App tells the user some more information about what the feature means.
            margins.Description = "The space between the content of your document and the edge of the paper";
    
            // Add the custom option to the option list
            displayedOptions.Add("Margins");
            
            printDetailedOptions.OptionChanged += printDetailedOptions_OptionChanged;
    
            // Print Task event handler is invoked when the print job is completed.
            printTask.Completed += (s, args) =>
            {
                // Notify the user when the print operation fails.
                if (args.Completion == PrintTaskCompletion.Failed)
                {
                    MainPage.Current.NotifyUser("Failed to print.", NotifyType.ErrorMessage);
                }
            };
    
            sourceRequestedArgs.SetSource(printDocumentSource);
    
            deferral.Complete();
        });
    }       

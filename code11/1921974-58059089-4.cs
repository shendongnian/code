    public void PrintTaskRequestedManifestLabel(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            // Create the PrintTask.
            // Defines the title and delegate for PrintTaskSourceRequested
            var printTask = args.Request.CreatePrintTask("Print", PrintTaskSourceRequestedManifestLabel);
            printTask.Options.Orientation = PrintOrientation.Landscape;
            
                
            // Handle PrintTask.Completed to catch failed print jobs
            printTask.Completed += PrintTaskCompletedManifestLabel;
        }

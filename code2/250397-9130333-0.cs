            PrintQueueCollection printQueues = null;
            List<PrinterDescription> printerDescriptions = null;
            // Get a list of available printers.
            this.printServer = new PrintServer();
            printQueues = this.printServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            printerDescriptions = new List<PrinterDescription>();
            foreach (PrintQueue printQueue in printQueues)
            {
                // The OneNote printer driver causes crashes in 64bit OSes so for now just don't include it.
                // Also redirected printer drivers cause crashes for some printers. Another WPF issue that cannot be worked around.
                if (printQueue.Name.ToUpperInvariant().Contains("ONENOTE") || printQueue.Name.ToUpperInvariant().Contains("REDIRECTED"))
                {
                    continue;
                }
                string status = printQueue.QueueStatus.ToString();
                try
                {
                    PrinterDescription printerDescription = new PrinterDescription()
                    {
                        Name = printQueue.Name,
                        FullName = printQueue.FullName,
                        Status = status == Strings.Printing_PrinterStatus_NoneTxt ? Strings.Printing_PrinterStatus_ReadyTxt : status,
                        ClientPrintSchemaVersion = printQueue.ClientPrintSchemaVersion,
                        DefaultPrintTicket = printQueue.DefaultPrintTicket,
                        PrintCapabilities = printQueue.GetPrintCapabilities(),
                        PrintQueue = printQueue
                    };
                    printerDescriptions.Add(printerDescription);
                }
                catch (PrintQueueException ex)
                {
                    // ... Logging removed
                }
            }

        // ---------------------- GetPrintTicketFromPrinter ----------------------- 
        /// <summary> 
        ///   Returns a PrintTicket based on the current default printer.</summary> 
        /// <returns> 
        ///   A PrintTicket for the current local default printer.</returns> 
        public PrintTicket GetPrintTicketFromPrinter()
        {
            PrintQueue printQueue = null;
            var localPrintServer = new LocalPrintServer();
            // Retrieving collection of local printer on user machine
            PrintQueueCollection localPrinterCollection = localPrintServer.GetPrintQueues();
            System.Collections.IEnumerator localPrinterEnumerator =
                localPrinterCollection.GetEnumerator();
            if (localPrinterEnumerator.MoveNext())
            {
                // Get PrintQueue from first available printer
                printQueue = (PrintQueue)localPrinterEnumerator.Current;
            }
            else
            {
                // No printer exist, return null PrintTicket 
                return null;
            }
            // Get default PrintTicket from printer
            PrintTicket printTicket = printQueue.DefaultPrintTicket;
            PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();
            // Modify PrintTicket 
            if (printCapabilites.PageMediaTypeCapability.Contains(PageMediaType.CardStock))
            {
                printTicket.PageMediaType = PageMediaType.CardStock;
            }
            return printTicket;
        }

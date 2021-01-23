        public static bool GetPrinterProperties(PrinterDescription selectedPrinter, bool showPrintingPreferencesDialog)
        {
            int modeGetSizeOfBuffer = 0;
            int modeCopy = 2;
            int modeOutBuffer = 14;
            IntPtr pointerHDevMode = new IntPtr();
            IntPtr pointerDevModeData = new IntPtr();
            try
            {
                PrintTicketConverter printTicketConverter = new PrintTicketConverter(selectedPrinter.FullName, selectedPrinter.ClientPrintSchemaVersion);
                IntPtr mainWindowPtr = new WindowInteropHelper(Application.Current.MainWindow).Handle;
                PrinterSettings printerSettings = new PrinterSettings();
                pointerHDevMode = printerSettings.GetHdevmode(printerSettings.DefaultPageSettings);
                IntPtr pointerDevMode = GlobalLock(pointerHDevMode);
                int sizeNeeded = DocumentProperties(mainWindowPtr, IntPtr.Zero, selectedPrinter.FullName, IntPtr.Zero, pointerDevMode, modeGetSizeOfBuffer);
                pointerDevModeData = Marshal.AllocHGlobal(sizeNeeded);
                int result = -1;
                if (!showPrintingPreferencesDialog)
                {
                    result = DocumentProperties(mainWindowPtr, IntPtr.Zero, selectedPrinter.FullName, pointerDevModeData, pointerDevMode, modeCopy);
                }
                else
                {
                    result = DocumentProperties(mainWindowPtr, IntPtr.Zero, selectedPrinter.FullName, pointerDevModeData, pointerDevMode, modeOutBuffer);
                }
                GlobalUnlock(pointerHDevMode);
                if (result == 1)
                {
                    byte[] devMode = new byte[sizeNeeded];
                    Marshal.Copy(pointerDevModeData, devMode, 0, sizeNeeded);
                    // set back new printing settings to selected printer.
                    selectedPrinter.DefaultPrintTicket = printTicketConverter.ConvertDevModeToPrintTicket(devMode);
                    return true;
                }
            }
            finally
            {
                GlobalFree(pointerHDevMode);
                Marshal.FreeHGlobal(pointerDevModeData);
            }
            return false;
        }

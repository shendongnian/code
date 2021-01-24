    private void ButCart_PrintOrder_Click(object sender, RoutedEventArgs e)
        {
            PosExplorer posExplorer = new PosExplorer();
            
            // Get connected printer devices
            DeviceCollection printers = posExplorer.GetDevices(DeviceType.PosPrinter);
            for (int i = 0; i < printers.Count; i++)
            {
                if (printers[i].ServiceObjectName == settings_ComboBox_Printer.Text)
                {
                    selectedPrinter = posExplorer.CreateInstance(printers[i]) as PosPrinter;
                }
            }
            try
            {
                selectedPrinter.Open();
                if (!selectedPrinter.Claimed)
                {
                    selectedPrinter.Claim(0);
                    selectedPrinter.DeviceEnabled = true;
                }
                
                bool printerReady = true;
                if (selectedPrinter.CoverOpen)
                {
                    MessageBox.Show("Printer cover is open.");
                    printerReady = false;
                }
                if (selectedPrinter.PowerState == PowerState.OffOffline)
                {
                    MessageBox.Show("Printer is has no power or is offline");
                    printerReady = false;
                }
                if (selectedPrinter.State != ControlState.Idle)
                {
                    MessageBox.Show("Printer is busy");
                    printerReady = false;
                }
                if (printerReady)
                {
                    string text = "test text";
                    selectedPrinter.PrintNormal(PrinterStation.Receipt, text);
                }
                
            }
            catch (Exception ae)
            {
                MessageBox.Show("An error occured: " + ae.ToString());
            }
        }

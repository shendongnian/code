    string GS = Convert.ToString((char)29);
    string ESC = Convert.ToString((char)27);
    string COMMAND = "";
    COMMAND = ESC + "@";
    COMMAND += GS + "V" + (char)1;
    PrintDialog pd = new PrintDialog();
    pd.PrinterSettings = new PrinterSettings();
    if (DialogResult.OK == pd.ShowDialog(this))
    {
    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName,  COMMAND);
    }

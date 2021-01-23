        private void startPrintingButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog(this))
            {
                PrintDocument pdoc = new PrintDocument();
                pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "ZDesigner GK420d";
                pdoc.DefaultPageSettings.Landscape = true;
                pdoc.DefaultPageSettings.PaperSize.Height = 140;
                pdoc.DefaultPageSettings.PaperSize.Width = 104;
                Print(pdoc.PrinterSettings.PrinterName, ofd.FileName);
            }
        }
        private void Print(string printerName, string fileName)
        {
            try
            {
                ProcessStartInfo gsProcessInfo;
                Process gsProcess;
                gsProcessInfo = new ProcessStartInfo();
                gsProcessInfo.Verb = "PrintTo";
                gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                gsProcessInfo.FileName = fileName;
                gsProcessInfo.Arguments = "\"" + printerName + "\"";
                gsProcess = Process.Start(gsProcessInfo);
                if (gsProcess.HasExited == false)
                {
                    gsProcess.Kill();
                }
                gsProcess.EnableRaisingEvents = true;
                gsProcess.Close();
            }
            catch (Exception)
            {
            }
        }

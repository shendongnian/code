        private void ExportToCSV(DataGrid dg)
        {
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result =(string)Clipboard.GetData(DataFormats.UnicodeText);
            string resultCSV = result.Replace('\t',',');
            //Save Location for the csv (not the actual Location)
            string SaveLocation = @"C:\Users\username\...\values"  + ".csv";
            
            //Overwriting previous values after exporting
            File.Delete(SaveLocation);
            File.AppendAllText(SaveLocation, result,Encoding.UTF8);
        }

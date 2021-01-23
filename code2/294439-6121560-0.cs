        static void Main(string[] args)
        {
            if (args.Length != 2)
                return;
            string filename = args[0];
            string password = args[1];
            if (!File.Exists(filename))
                return;
            Excel.Application oexcel;
            Excel.Workbook obook;
            oexcel = new Excel.Application();
            oexcel.DisplayAlerts = false;
            obook = oexcel.Workbooks.Open(filename, 0, false, 5, "", "", true, System.Reflection.Missing.Value, "\t", false, false, 0, true, 1, 0);
            try
            {
                obook.SaveAs(filename, Password: password, ConflictResolution: XlSaveConflictResolution.xlLocalSessionChanges);
            }
            finally
            {
                obook.Close();
                oexcel.Quit();
            }
        }

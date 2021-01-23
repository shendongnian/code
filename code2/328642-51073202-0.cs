    private void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;
            foreach (var process in processes)
            {
                MessageBox.Show(process.MainWindowTitle);
                if (process.MainWindowTitle == excelFileName)
                {
                
                process.Kill();
                }
            }
        }

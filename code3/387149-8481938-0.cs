            //preload crystal reports on a seperate thread
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        using (ReportDocument preloadCrystalReport = new ReportDocument())
                        {
                            preloadCrystalReport.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports/Report.rpt"));
                            PrintPreview preloadCrystalGUI = new PrintPreview().Init(preloadCrystalReport);
                            preloadCrystalGUI.Dispose();
                        }
                    }
                    catch (Exception e)
                    {
                        \\log exception
                    }
                }, TaskCreationOptions.LongRunning);

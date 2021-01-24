    for (int i = 1; i < pageCount; i++)
                    {
                        if (!backgroundWorker.CancellationPending)
                        {
                            backgroundWorker.ReportProgress(index++ * 100 / pageCount);
                            Thread.Sleep(delay);
                            wb.Sheets.Add(missing,After:wb.Sheets[wb.Sheets.Count],Count:missing,
    Type:template);
                            //Worksheet ws = (Worksheet)wb.Sheets[wb.Sheets.Count];
                        }
                    }

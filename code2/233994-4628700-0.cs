    var openedExcel = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                if (openedExcel.Any())
                {
                    foreach (var excel in openedExcel)
                    {
                        try { excel.Kill(); }
                        catch { }
                    }
                }

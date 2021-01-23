                foreach (Excel.Worksheet ws in wb.Worksheets)
                {
                    Excel.PageSetup ps = (Excel.PageSetup)ws.PageSetup;
                    ws.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                    ws.PageSetup.Order = Excel.XlOrder.xlDownThenOver;
                    ws.PageSetup.FitToPagesWide = 1;
                    ws.PageSetup.FitToPagesTall = 50;
                    ws.PageSetup.Zoom = false;  
                }
                wb.Worksheets.PrintOutEx();  

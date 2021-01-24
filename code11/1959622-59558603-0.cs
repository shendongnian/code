    GenerateExcel("OutputFile" + DateTime.Now.ToString("MMddyyyyhhmmss"), result);
    if (Cnt != 0)
                {
                    TempData["Error"] = "There were issues with the Excel Import: Total Records: " + result.Rows.Count+" Error Row Count: "+Cnt;
                }
                else
                {
                    TempData["Error"] = "No error found in given excel: Total Records: " + result.Rows.Count;
                }
                return View();

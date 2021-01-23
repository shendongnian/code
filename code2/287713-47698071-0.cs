     private static void ProcessTemplate(Stream template, Dictionary<string,string> toReplace)
            {
                using (var workbook = SpreadsheetDocument.Open(template, true, new OpenSettings { AutoSave = true }))
                {
    
                    workbook.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                    workbook.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
    
                    //Replace  SheetNames
                    foreach (Sheet sheet in workbook.WorkbookPart.Workbook.Sheets)
                        foreach (var key in toReplace.Keys)
                            sheet.Name.Value = sheet.Name.Value.Replace(key, toReplace[key]);
    
                    foreach (WorksheetPart wsheetpart in workbook.WorkbookPart.WorksheetParts)
                        foreach (SheetData sheetd in wsheetpart.Worksheet.Descendants<x.SheetData>())
                            foreach (Row r in wsheetpart.Worksheet.Descendants<x.Row>())
                                foreach (Cell c in r.Descendants<x.Cell>())
                                    if (c.CellFormula != null)
                                    {
                                        foreach (var key in toReplace.Keys)
                                            c.CellFormula.Text = c.CellFormula.Text.Replace(key, toReplace[key]);
                                    }
                                        
                                    // Replace shared strings
                                    SharedStringTablePart sharedStringsPart = workbook.WorkbookPart.SharedStringTablePart;
                    
                    IEnumerable<x.Text> sharedStringTextElements = sharedStringsPart.SharedStringTable.Descendants<x.Text>();
                    for(int i =0;i<toReplace.Keys.Count; i++)
                        DoReplace(sharedStringTextElements, toReplace);
    
                    IEnumerable<x.Formula> sharedStringTextElementsF = sharedStringsPart.SharedStringTable.Descendants<x.Formula>();
                    for (int i = 0; i < toReplace.Keys.Count; i++)
                        DoReplaceFormula(sharedStringTextElementsF, toReplace);
    
                    // Replace inline strings
                    IEnumerable<WorksheetPart> worksheetParts = workbook.GetPartsOfType<WorksheetPart>();
                    foreach (var worksheet in worksheetParts)
                    {
    
                        var allTextElements = worksheet.Worksheet.Descendants<x.Text>();
                        DoReplace(allTextElements, toReplace);
    
                        var allTextElements2 = worksheet.Worksheet.Descendants<x.Formula>();
                        DoReplaceFormula(allTextElements2, toReplace);
    
                    }
    
                } // AutoSave enabled
            }

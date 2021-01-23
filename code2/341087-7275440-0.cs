        [WebMethod]
        public byte[] MergeFiles(FileFormat saveAsFileFormat, List<byte[]> inputFileBytesList)
        {
            //var outputFilePath = Path.Combine(Properties.Settings.Default.WorkingFolder, Guid.NewGuid() + ".xls");
            var outputFilePath = Path.Combine(Properties.Settings.Default.WorkingFolder, "target.xls");
            Impersonate(
                Properties.Settings.Default.ImpersonationUser.Decrypt(),
                Properties.Settings.Default.ImpersonationDomain,
                Properties.Settings.Default.ImpersonationPassword.Decrypt()
            );
            var convertedFileList = new List<string>();
            foreach (var inputFileBytes in inputFileBytesList)
            {
                var inputFileExtension = GetExtension(inputFileBytes);
                var inputFilePath = Path.Combine(Properties.Settings.Default.WorkingFolder, Guid.NewGuid() + inputFileExtension);
                File.WriteAllBytes(inputFilePath, inputFileBytes);
                
                var convertedFilePath = Path.Combine(Properties.Settings.Default.WorkingFolder, Guid.NewGuid() + inputFileExtension);
                SaveAsInternal(saveAsFileFormat, inputFilePath, convertedFilePath, true);
                convertedFileList.Add(convertedFilePath);
            }
            // Target Excel File
            object excelApplication = null;
            object excelWorkbooks = null;
            object targetWorkbook = null;
            object targetWorksheets = null;
            object targetWorksheet = null;
            try
            {
                // Get the Remote Type
                var excelType = Type.GetTypeFromProgID("Excel.Application", Properties.Settings.Default.ExcelServer, true);
                // Instantiate the type
                excelApplication = Activator.CreateInstance(excelType);
                // Turn off Prompts
                excelApplication.GetType().InvokeMember(
                    "DisplayAlerts",
                    BindingFlags.SetProperty,
                    null,
                    excelApplication,
                    new Object[] { false });
                // Get a reference to the workbooks object
                excelWorkbooks = excelApplication.GetType().InvokeMember(
                    "Workbooks",
                    BindingFlags.GetProperty,
                    null,
                    excelApplication,
                    null);
                // Create a workbook to add the sheets to
                targetWorkbook = excelWorkbooks.GetType().InvokeMember(
                    "Add",
                    BindingFlags.InvokeMethod,
                    null,
                    excelWorkbooks,
                    new object[] { 1 });
                // Get a reference to the worksheets object
                targetWorksheets = targetWorkbook.GetType().InvokeMember(
                    "Sheets",
                    BindingFlags.GetProperty,
                    null,
                    excelApplication,
                    null
                    );
                // Open each File, grabbing all tabs
                foreach (var inputFilePath in convertedFileList)
                {
                    object sourceWorkbook = null;
                    object sourceWorksheets = null;
                    try
                    {
                        // Open the input file
                        sourceWorkbook = excelWorkbooks.GetType().InvokeMember(
                            "Open",
                            BindingFlags.InvokeMethod,
                            null,
                            excelWorkbooks,
                            new object[] {inputFilePath});
                        // Get a reference to the worksheets object
                        sourceWorksheets = sourceWorkbook.GetType().InvokeMember(
                            "Sheets",
                            BindingFlags.GetProperty,
                            null,
                            excelApplication,
                            null);
                        var sourceSheetCount = (int)(sourceWorksheets.GetType().InvokeMember(
                            "Count",
                            BindingFlags.GetProperty,
                            null,
                            sourceWorksheets,
                            null));
                        
                        for (var i = 1; i <= sourceSheetCount; i++)
                        {
                            var targetSheetCount = (int)(targetWorksheets.GetType().InvokeMember(
                                "Count",
                                BindingFlags.GetProperty,
                                null,
                                targetWorksheets,
                                null));
                            var sourceWorksheet = sourceWorksheets.GetType().InvokeMember(
                                "Item",
                                BindingFlags.GetProperty,
                                null,
                                sourceWorksheets,
                                new Object[] { i });
                            targetWorksheet = targetWorksheets.GetType().InvokeMember(
                                "Item",
                                BindingFlags.GetProperty,
                                null,
                                targetWorksheets,
                                new Object[] { targetSheetCount });
                            // TODO: Copy into target file
                            sourceWorksheet.GetType().InvokeMember(
                                "Copy",
                                BindingFlags.InvokeMethod,
                                null,
                                sourceWorksheet,
                                new[] { Type.Missing, targetWorksheet }
                                );
                            if (sourceWorksheet != null)
                            {
                                Marshal.ReleaseComObject(sourceWorksheet);
                                sourceWorksheet = null;
                            }
                        }
                    }
                    finally
                    {
                        // Cleanup all created COM objects
                        if (sourceWorksheets != null)
                        {
                            Marshal.ReleaseComObject(sourceWorksheets);
                            sourceWorksheets = null;
                        }
                        if (sourceWorkbook != null)
                        {
                            sourceWorkbook.GetType().InvokeMember(
                                "Close",
                                BindingFlags.InvokeMethod,
                                null,
                                sourceWorkbook,
                                null);
                            Marshal.ReleaseComObject(sourceWorkbook);
                            sourceWorkbook = null;
                        }
                    }
                }
                // If overwrite is turned off, and the file exist, the save as line will throw an error
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
                // Save the workbook
                targetWorkbook.GetType().InvokeMember(
                    "SaveAs",
                    BindingFlags.InvokeMethod,
                    null,
                    targetWorkbook,
                    new object[] { outputFilePath, saveAsFileFormat, null, null, null, null, 1, null, null, null, null, null });
            }
            finally
            {
                // Cleanup all created COM objects
                if (targetWorksheets != null)
                {
                    Marshal.ReleaseComObject(targetWorksheets);
                    targetWorksheets = null;
                }
                if (targetWorkbook != null)
                {
                    targetWorkbook.GetType().InvokeMember(
                        "Close",
                        BindingFlags.InvokeMethod,
                        null,
                        targetWorkbook,
                        null);
                    Marshal.ReleaseComObject(excelWorkbooks);
                    excelWorkbooks = null;
                }
                if (excelWorkbooks != null)
                {
                    Marshal.ReleaseComObject(excelWorkbooks);
                    excelWorkbooks = null;
                }
                if (excelApplication != null)
                {
                    excelApplication.GetType().InvokeMember(
                        "Quit",
                        BindingFlags.InvokeMethod,
                        null,
                        excelApplication,
                        null);
                    Marshal.ReleaseComObject(excelApplication);
                    excelApplication = null;
                }
            }
            // Read target file bytes
            var resultBytes = (File.Exists(outputFilePath))
                ? File.ReadAllBytes(outputFilePath)
                : new byte[] { };
            // Delete working files
            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);
            foreach (var inputFilePath in convertedFileList.Where(File.Exists))
            {
                File.Delete(inputFilePath);
            }
            
            Repersonate();
            // Return result
            return resultBytes;
        }

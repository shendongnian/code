            public static Excel.Workbook Open(Excel.Application excelInstance,
                    string fileName, bool readOnly = false, bool editable = true,
                    bool updateLinks = true)
            {
                Excel.Workbook book = excelInstance.Workbooks.Open(
                    fileName, updateLinks, readOnly,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                return book;
            }
        }
    }

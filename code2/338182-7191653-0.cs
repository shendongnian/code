        Excel.Workbook wbXL = null;
        try
        {
            wbxl = appXL.Workbooks.Open(_sourceFullPath, Type.Missing,
                                        Excel.XlFileAccess.xlReadOnly);
            //stuff with wbXL
        }
        finally
        {
            if (wbxl != null) wbxl.Close();
        }

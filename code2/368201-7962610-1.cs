            // There is no column name In a Excel spreadsheet.  
            // So we specify "HDR=YES" in the connection string to use  
            // the values in the first row as column names.  
            if (strExtension == ".xls")
            {
                // Excel 97-2003 
                strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(strUploadFileName) + ";Extended Properties=\"Excel 8.0;HDR=Yes;\"";
                //if the above doesn't work, you may need to prefix OLEDB; to the string, e.g.
                //strExcelConn = "OLEDB;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(strUploadFileName) + ";Extended Properties=\"Excel 8.0;HDR=Yes;\"";
            }
            else
            {
                // Excel 2007 
                strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(strUploadFileName) + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            }

    IExcelDataReader rdr = null;
                try
                {
                        using (MemoryStream ms = new MemoryStream(mySheet.Payload)) //Payload is the byte array
                        {
                            ms.Position = 0;
                            string ext = Path.GetExtension(mySheet.FileName); //filename is the filename
        
                            switch (ext)
                            {
                                case ".xls": //Old style (2003 or less)
                                    rdr = ExcelReaderFactory.CreateBinaryReader(ms);
                                    break;
                                case ".xlsx": //New style (2007 or higher)
                                    rdr = ExcelReaderFactory.CreateOpenXmlReader(ms);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException(String.Format("File extension {0} is not recognized as valid", ext));
                            }
        
                            using (DataSet ds = rdr.AsDataSet())
                            {
                                int rowNumber = 2;
                                DataTable dt = ds.Tables[0];
                                DataView dv = ds.DefaultViewManager.CreateDataView(ds.Tables[0]);
        
                                foreach (DataRow row in rows)
                                { ... logic in here ... }
                             }
                        }
    }
    catch(Exception ex)
    {
    }

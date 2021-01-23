            try
                {
                      //You get your file in a byteArray fileType is just the ordinal file position in the fileattachment field..ex. 1, 2, 3 (shown in the access listbox)
                    Response.BinaryWrite(GetPicField(productID, fileType));
                    Response.ContentType = "image/bmp";
                }
                catch 
                {
                    //need to get missing product photo image here as well N/A
                    Response.BinaryWrite(GetNA_Image());
                    Response.ContentType = "image/bmp";
                }
        //getting from Database
        private byte[] GetPicField(string productID,int fileToShow)
        {
            DBEngine dbe = new DBEngine();
            Database db;
            Recordset rs;
          
            byte[] byteArray = null;
            dbe = new DBEngine();
            db = dbe.OpenDatabase(Application["DB_FileName"].ToString());
            rs = db.OpenRecordset("SELECT PIC FROM PRODUCT WHERE PRODUCTID = " + productID, RecordsetTypeEnum.dbOpenForwardOnly, 0, LockTypeEnum.dbPessimistic);
            
            if (rs.RecordCount > 0)
            {
              
                Recordset rs2 = (Recordset2)rs.Fields["Pic"].Value;
                int i = 1;
                while (i < fileToShow)
                {
                    rs2.MoveNext();
                    i++;
                }
           
              //get the thubmnail
               Field2 f2 = (Field2)rs2.Fields["FileData"]; //0 is first pic
                byteArray = f2.GetChunk(20, f2.FieldSize - 20);
               
                System.Runtime.InteropServices.Marshal.ReleaseComObject(f2);
                rs2.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rs2);
                f2 = null;
                rs2 = null;
            }
            rs.Close();
            db.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(dbe);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(db);
            rs = null;
            db = null;
            dbe = null;
            return byteArray;
           
        }

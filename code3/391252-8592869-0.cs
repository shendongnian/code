    string strExtenstion = “extension of retrieved file”;
                        byte[] bytFile =  “Byte array retrieved from database”;
        
                        Response.Clear();
                        Response.Buffer = true;
        
                        if (strExtenstion == “.pdf”)
                        {
                                Response.ContentType = “application/pdf”;
                                Response.AddHeader(“content-disposition”, 
                                       “attachment;filename=someFilename.pdf”);
                        }
        
                        Response.Charset = “”;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        
                        // If you write,
                        // Response.Write(bytFile1);
                        // then you will get only 13 byte in bytFile.
                        Response.BinaryWrite(bytFile);
        
                        Response.End();

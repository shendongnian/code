                        Byte[] fileData = GetDocument(filePath);
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.ContentType = "application/pdf";
                        // prompt to download
                        Response.AddHeader("content-disposition", "attachment; filename=downloadNameHere.pdf");
                        Response.BinaryWrite(fileData);
                        Response.Flush();
                        Response.Close();

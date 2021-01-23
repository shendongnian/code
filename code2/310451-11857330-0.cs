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

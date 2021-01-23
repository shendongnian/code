      /// <summary>
            /// returns the virtual application path of uploaded file.
            /// </summary>
            /// <param name="fu"></param>
            /// <param name="uploadType"></param>
            /// <returns></returns>
            public static string GetAppFileUploadPath(FileUpload fu, UploadTypes uploadType, int userId)
            {
               var path =  string.Format("~/Images/no.gif"); 
    
                if (fu.HasFile)
                {
                    if (fu.FileContent.Length > 0)
                    {
                        var filename = Path.GetFileNameWithoutExtension(fu.PostedFile.FileName);
                        var extension = Path.GetExtension(fu.PostedFile.FileName);
                        switch (uploadType)
                        {
                            case UploadTypes.Images:
                                _validExtensions = new List<string> 
                                                    {
                                                        ".bmp", ".jpg",".jpeg",".gif",".png" 
                                                    };
                               
                                if (_validExtensions.Contains(extension.ToLower()))
                                {
                                    var newFileName = string.Format("{0}_{1}_{2}{3}", filename, userId, Guid.NewGuid().ToString().Substring(0, 5), extension);
                                    var serverUploadPath = string.Format("{0}/VirtualOffice/Uploads/ProductImage/{1}", HttpRuntime.AppDomainAppPath, newFileName);
                                    path = string.Format("~/VirtualOffice/Uploads/ProductImage/{0}", newFileName);
                                    fu.SaveAs(serverUploadPath);
    
                                }
                                else
                                {
                                    Common.ShowMessage("Only image files allowed, bmp, jpg , gif or png.");
                                }
                                break;
                            case UploadTypes.Documents:
                                _validExtensions = new List<string> 
                                                    {
                                                        ".doc", ".rtf",".docx",".pdf",".txt" 
                                                    };
                                if (_validExtensions.Contains(extension.ToLower()))
                                {
                                    var newFileName = string.Format("{0}_{1}_{2}{3}", filename, userId, Guid.NewGuid().ToString().Substring(0, 5), extension);
                                    var serverUploadPath = string.Format("{0}/VirtualOffice/Uploads/ProductImage/{1}", HttpRuntime.AppDomainAppPath, newFileName);
                                    fu.SaveAs(serverUploadPath);
                                    path = string.Format("~/VirtualOffice/Uploads/ProductImage/{0}", newFileName);
                                }
                                else
                                {
                                    Common.ShowMessage("Only valid text files allowed, doc, docx ,rtf, pdf or txt.");
                                   
                                }
                                break;
                        }
    
                    }
                }
    
                return path;
    
            }

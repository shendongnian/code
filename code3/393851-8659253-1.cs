    //notice I overloaded
    private void downloadList(SPWeb oWeb){
    //get subwebs of subwebs
    foreach(SPWeb oWeb in currentWeb.Webs){
    
       downloadList(oWeb); 
    
    }
    foreach (SPList list in oWeb.Lists)
                {
                        foreach (SPFolder oFolder in list.Folders)
                        {
                            if (oFolder != null)
                            {
                                foreach (SPFile file in oFolder.files)
                                {
                                    if (CreateDirectoryStructure(tbDirectory.Text, file.Url))
                                    {
                                        var filepath = System.IO.Path.Combine(tbDirectory.Text, file.Url);
                                        byte[] binFile = file.OpenBinary();
                                        System.IO.FileStream fstream = System.IO.File.Create(filepath);
                                        fstream.Write(binFile, 0, binFile.Length);
                                        fstream.Close();
                                    }
                                }
                            }
                    }
                }
            }
    }

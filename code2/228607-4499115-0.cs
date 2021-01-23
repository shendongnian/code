         SPSite _MySite = new SPSite("http://adfsaccount:2222/");
                    SPWeb _MyWeb = _MySite.OpenWeb();
         
                    SPDocumentLibrary _MyDocLibrary = (SPDocumentLibrary) _MyWeb.Lists["My Documents"];
                    SPFolderCollection _MyFolders = _MyWeb.Folders;
                    _MyFolders.Add("http://adfsaccount:2222/My%20Documents/" + txtUpload.Text + "/");
                    _MyDocLibrary.Update();
    _MyWeb.Dispose();
    _MySite .Dispose();
